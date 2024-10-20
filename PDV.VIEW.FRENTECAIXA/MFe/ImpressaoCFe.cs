using ACBr.Net.Sat;
using BarcodeLib;
using CrystalDecisions.Shared;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.Common;

namespace CFeImpressao
{
    public class ImpressaoCFe
    {
        public CFe Cfe { get; }
        private DsCFe DataSet { get; set; }
        public ImpressaoCFe(CFe cfe)
        {
            Cfe = cfe;
            DataSet = new DsCFe();
        }

        private byte[] GetQRCode()
        {
            string qrCode = Cfe.GetQRCode();

            BarcodeWriter bw = new BarcodeWriter();
            EncodingOptions encOptions = new EncodingOptions { Width = 300, Height = 300, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = BarcodeFormat.QR_CODE;
            Bitmap image = new Bitmap(bw.Write(qrCode));

            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        private DataTable GetCabecalho()
        {
            var emit = Cfe.InfCFe.Emit;
            var ender = emit.EnderEmit;

            Barcode barcode = new Barcode();
            barcode.Encode(TYPE.CODE128, Cfe.InfCFe.Id.Replace("CFe", ""));
            byte[] barcodeArray = barcode.GetImageData(SaveTypes.JPG);

            var dt = DataSet.Cabecalho;
            dt.Rows.Add(
                   emit.XFant,
                   emit.XNome,
                   emit.CNPJ,
                   $"{ender.XLgr}, {ender.Nro} - {ender.XBairro}, {ender.XMun}",
                   Cfe.InfCFe.Ide.CNf,
                   Cfe.InfCFe.Ide.NCFe,
                   Cfe.InfCFe.Ide.DhEmissao,
                   Cfe.InfCFe.Id.Replace("CFe", ""),
                   barcodeArray,
                   GetQRCode()
                 );
            return dt;
        }

        private DataTable GetItens()
        {
            var dt = DataSet.Itens;
            foreach (var item in Cfe.InfCFe.Det)
            {
                dt.Rows.Add(
                        item.Prod.CProd,
                        item.Prod.XProd,
                        item.Prod.QCom,
                        item.Prod.VUnCom,
                        item.Prod.VProd,
                        item.Prod.UCom,
                        item.NItem
                    );
            }

            return dt;
        }

        private string GetNomeFormaPg(CFePgtoMp pag)
        {
            switch (pag.CMp)
            {
                case CodigoMP.Dinheiro: return "Dinheiro";
                case CodigoMP.CartaodeDebito: return "Cartão Débito";
                case CodigoMP.CartaodeCredito: return "Cartão Crédito";
                case CodigoMP.Cheque: return "Cheque";
                default: return "Outros pagamentos";
            }
        }

        private DataTable GetPag()
        {
            var dt = DataSet.Pagamentos;
            foreach (var pag in Cfe.InfCFe.Pagto.Pagamentos)
            {
                string formaPg = GetNomeFormaPg(pag);
                decimal valor = pag.VMp;
                dt.Rows.Add(formaPg, valor);
            }
            return dt;
        }

        private DataTable GetTotais()
        {
            var dt = DataSet.Totais;
            dt.Rows.Add(
                   Cfe.InfCFe.Det.Sum(t => t.Prod.VProd),
                   Cfe.InfCFe.Total.ICMSTot.VDesc,
                   Cfe.InfCFe.Total.VCFe,
                   Cfe.InfCFe.InfAdic.InfCpl,
                   Cfe.InfCFe.Pagto.VTroco
                );
            return dt;
        }

        private DataTable GetCliente()
        {
            var dt = DataSet.Cliente;
            if (Cfe.InfCFe.Dest != null)
            {
                string cpfCnpj = (string.IsNullOrEmpty(Cfe.InfCFe.Dest.CPF)
                    ? Cfe.InfCFe.Dest.CNPJ
                    : Cfe.InfCFe.Dest.CPF);
                dt.Rows.Add(Cfe.InfCFe.Dest.Nome, cpfCnpj);
            }
            else dt.Rows.Add("Consumidor não identificado", "");
            return dt;
        }

        public string  ObterTexto ()
        {
            string TxtImpressao = "";

            ReportController rc = new ReportController();
            rc.AddDataSource("Cabecalho", GetCabecalho());
            rc.AddDataSource("Itens", GetItens());
            rc.AddDataSource("Pagamentos", GetPag());
            rc.AddDataSource("Totais", GetTotais());
            rc.AddDataSource("Cliente", GetCliente());

            var rpt = rc.GetReportDocument("CupomCFe.rpt");
            var stram = rpt.ExportToStream(ExportFormatType.CharacterSeparatedValues);
            using (MemoryStream ms = new MemoryStream())
            {
                stram.CopyTo(ms);
                byte[] buffer = ms.ToArray();
                TxtImpressao = Encoding.UTF8.GetString(buffer);
            }

            return TxtImpressao;
        }

        public void ImprimirCFe(string nomeImpressora)
        {
            ReportController rc = new ReportController();
            rc.AddDataSource("Cabecalho", GetCabecalho());
            rc.AddDataSource("Itens", GetItens());
            rc.AddDataSource("Pagamentos", GetPag());
            rc.AddDataSource("Totais", GetTotais());
            rc.AddDataSource("Cliente", GetCliente());

            var rpt = rc.GetReportDocument("CupomCFe.rpt");
            rc.PrintToMiniPrinter(rpt,
                "Não foi possível imprimir o cupom", $"CFe {Cfe.InfCFe.Id}.pdf",
                nomeImpressora, true);
        }

        public void ImprimirCFeCancelado(string nomeImpressora)
        {
            ReportController rc = new ReportController();
            rc.AddDataSource("Cabecalho", GetCabecalho());
            rc.AddDataSource("Itens", GetItens());
            rc.AddDataSource("Pagamentos", GetPag());
            rc.AddDataSource("Totais", GetTotais());
            rc.AddDataSource("Cliente", GetCliente());

            var rpt = rc.GetReportDocument("CupomCFe_Cancelamento.rpt");
            rc.PrintToMiniPrinter(rpt,
                "Não foi possível imprimir o cupom", $"CFe {Cfe.InfCFe.Id}.pdf",
                nomeImpressora, true);
        }
    }
}

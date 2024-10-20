using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using BarcodeLib;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.Classes
{
    public class ImpressaoFiscal
    {

        //definição das variáveis visiveis no formulário
        //Private Usuario As usuario

        private int Bobina;

        private float Linha;
        private float LinhaAtual;

        private Font FonteNegrito;
        private Font FonteTitulo;
        private Font FonteSubtitulo;
        private Font FonteRodape;
        private Font FonteNormal;
        private Font FonteSublinhada;

        private Barcode barcode = new Barcode();

        private QrCode QrcodeX;
        private QrEncoder QrEncoder = new QrEncoder(ErrorCorrectionLevel.H);

        private Pen CanetaDaImpressora;

        private ACBr.Net.Sat.CFe Cfe = new ACBr.Net.Sat.CFe();

        private string Erro;
        private bool CfeCancelamento;

        public void ImprimirCFe(ACBr.Net.Sat.CFe CfeAtual, bool Cancelamento = false)
        {

            if (ReferenceEquals(CfeAtual, null))
            {
                MessageBox.Show("Cupom não carregado para impressão", "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cfe = CfeAtual;
            }

            CfeCancelamento = Cancelamento;

            string ImpressoraPadrao = "";

            try
            {
                //define os objetos printdocument e os eventos associados
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                PrintPreviewDialog preview = new PrintPreviewDialog();
                ImpressoraPadrao = pd.PrinterSettings.PrinterName;
                System.Drawing.Printing.PaperSize PapelPersonal = default(System.Drawing.Printing.PaperSize);

                //IMPORTANTE - definimos 3 eventos para tratar a impressão : PringPage, BeginPrint e EndPrint.
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PdRelatorios_PrintPage);

                //classe Pen define um objeto usado para definir linhas e curvas
                CanetaDaImpressora = new Pen(Color.Black, 1);

                Bobina = System.Convert.ToInt32(System.Math.Round(80 * 3.77, 0));

                //Seta o papel personalizado e converte o valor do tamanho da bobina de Minimetros para pixels
                PapelPersonal = new System.Drawing.Printing.PaperSize("personal", Bobina + 20, 90000);
                pd.DefaultPageSettings.PaperSize = PapelPersonal;

                pd.PrinterSettings.PrinterName = ImpressoraPadrao;

                pd.Print();

            }
            catch (System.Drawing.Printing.InvalidPrinterException)
            {

                MessageBox.Show("Impressora não cadastrada", "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir: " + ex.GetBaseException().ToString() + "\r\n" + Erro, "Erro Fatal");
            }

        }
        private void IniciarFontes()
        {
            try
            {
                FonteNegrito = new Font("Letter Gothic", 9, FontStyle.Bold);
                FonteTitulo = new Font("Arial", 11, FontStyle.Bold);
                FonteSubtitulo = new Font("Arial", 10, FontStyle.Bold);
                FonteRodape = new Font("Letter Gothic", 7);
                FonteNormal = new Font("Letter Gothic", 8);
                FonteSublinhada = new Font("Letter Gothic", 8, FontStyle.Underline);

            }
            catch (Exception)
            {
                Erro = "Erro ao iniciar as fontes";
            }
        }
        private void ImprimirCabecalho(System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                //Dados da empresa emitente
                e.Graphics.DrawString(Cfe.InfCFe.Emit.XFant, FonteTitulo, Brushes.Black, 30, Linha, new StringFormat()); //Nome fantasia
                Linha += FonteTitulo.Height + 10;
                e.Graphics.DrawString(Cfe.InfCFe.Emit.XNome, FonteSubtitulo, Brushes.Black, 40, Linha, new StringFormat()); //Razão social
                Linha += FonteNormal.Height + 10;
                e.Graphics.DrawString(Cfe.InfCFe.Emit.EnderEmit.XLgr + ", " + Cfe.InfCFe.Emit.EnderEmit.Nro + " " + Cfe.InfCFe.Emit.EnderEmit.XBairro + " " + Cfe.InfCFe.Emit.EnderEmit.XMun, FonteRodape, Brushes.Black, 15, Linha, new StringFormat()); //Endereco
                Linha += FonteRodape.Height + 5;
                e.Graphics.DrawString("CNPJ:" + Cfe.InfCFe.Emit.CNPJ + " IE:" + Cfe.InfCFe.Emit.IE, FonteRodape, Brushes.Black, 40, Linha, new StringFormat()); //CNPJ + IE

                //linha separatória
                Linha += FonteNormal.Height;
                e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));

                //dados do SAT
                Linha += 10;
                e.Graphics.DrawString("Extrato Nº " + String.Format(Cfe.InfCFe.Ide.NCFe.ToString(), "000000"), FonteTitulo, Brushes.Black, 70, Linha, new StringFormat()); //Razão social
                Linha += FonteNormal.Height + 5;
                e.Graphics.DrawString("CUPOM FISCAL ELETRÔNICO - SAT", FonteTitulo, Brushes.Black, 5, Linha, new StringFormat()); //Razão social
                Linha += FonteTitulo.Height + 10;

                //dados do destinatário
                if (!ReferenceEquals(Cfe.InfCFe.Dest.CNPJ, null))
                {
                    e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
                    Linha += 3;
                    e.Graphics.DrawString("CPF/CNPJ do Consumidor:" + Cfe.InfCFe.Dest.CNPJ, FonteNormal, Brushes.Black, 15, Linha, new StringFormat()); //Razão social
                    if (!ReferenceEquals(Cfe.InfCFe.Dest.Nome, null))
                    {
                        Linha += FonteNormal.Height + 5;
                        e.Graphics.DrawString("Razão Social/Nome:" + Cfe.InfCFe.Dest.Nome, FonteNormal, Brushes.Black, 15, Linha, new StringFormat()); //Razão social
                    }
                    Linha += FonteNormal.Height;
                }
                else if (!ReferenceEquals(Cfe.InfCFe.Dest.CPF, null))
                {
                    e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
                    Linha += 3;
                    e.Graphics.DrawString("CPF/CNPJ do Consumidor:" + Cfe.InfCFe.Dest.CPF, FonteNormal, Brushes.Black, 15, Linha, new StringFormat()); //Razão social
                    if (!ReferenceEquals(Cfe.InfCFe.Dest.Nome, null))
                    {
                        Linha += FonteNormal.Height + 5;
                        e.Graphics.DrawString("Razão Social/Nome:" + Cfe.InfCFe.Dest.Nome, FonteNormal, Brushes.Black, 15, Linha, new StringFormat()); //Razão social
                    }
                    //linha separatória
                    Linha += FonteNormal.Height;
                }

            }
            catch (Exception)
            {
                Erro = "Erro ao Imprimir cabeçalho";
            }
        }
        private void ImprimirDadosEntrega(System.Drawing.Printing.PrintPageEventArgs e)
        {

            SizeF linhadeimpressao_end = new SizeF(Bobina - 40, FonteNormal.Height);

            try
            {
                if (!string.IsNullOrEmpty(Cfe.InfCFe.Entrega.XLgr) || !string.IsNullOrEmpty(Cfe.InfCFe.Entrega.Nro) || !string.IsNullOrEmpty(Cfe.InfCFe.Entrega.XCpl) || !string.IsNullOrEmpty(Cfe.InfCFe.Entrega.XBairro))
                {
                    e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
                    e.Graphics.DrawString("DADOS PARA ENTREGA", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    Linha += FonteNormal.Height;
                    e.Graphics.DrawString("End:" + Cfe.InfCFe.Entrega.XLgr + " ," + Cfe.InfCFe.Entrega.Nro, FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    Linha += FonteNormal.Height;
                    e.Graphics.DrawString(Cfe.InfCFe.Entrega.XCpl + " " + Cfe.InfCFe.Entrega.XBairro + " " + Cfe.InfCFe.Entrega.XMun + "-" + Cfe.InfCFe.Entrega.UF, FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    Linha += FonteNormal.Height;
                    e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
                }
            }
            catch
            {
                Erro = "Erro ao imprimir os dados da entrega";
                throw;
            }

        }
        private void ImprimirProdutos(System.Drawing.Printing.PrintPageEventArgs e)
        {

            decimal totalitem = 0;
            decimal unditem = 0;
            decimal altitem = 0;

            short i = (short)0;

            try
            {
                e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
                Linha += 3;
                e.Graphics.DrawString("#|COD |DESC |QTD |UN |VL UN R$ |(VLTR R$)* |VL ITEM R$", FonteRodape, Brushes.Black, 5, Linha, new StringFormat()); //CAbeçalho Produtos
                Linha += FonteNormal.Height;
                e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
                Linha += 5;

                for (i = 0; i <= Cfe.InfCFe.Det.Count - 1; i++)
                {
                    e.Graphics.DrawString(Cfe.InfCFe.Det[i].NItem.ToString("000") + " "
                        + Cfe.InfCFe.Det[i].Prod.CProd + " "
                        + Cfe.InfCFe.Det[i].Prod.XProd, FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    Linha += FonteNormal.Height;
                    e.Graphics.DrawString(Cfe.InfCFe.Det[i].Prod.QCom + " x "
                        + Cfe.InfCFe.Det[i].Prod.UCom + " "
                        + System.Convert.ToString(Cfe.InfCFe.Det[i].Prod.VUnCom) + " ("
                        + System.Convert.ToString(Cfe.InfCFe.Det[i].Imposto.VItem12741) + ")", FonteNormal, Brushes.Black, 15, Linha, new StringFormat());
                    e.Graphics.DrawString(System.Convert.ToString(Cfe.InfCFe.Det[i].Prod.VProd), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                    Linha += FonteNormal.Height + 5;

                    if (Cfe.InfCFe.Det[i].Prod.VDesc > 0) //verifica se há descontos no cupom de venda
                    {
                        e.Graphics.DrawString("desconto sobre o item", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                        e.Graphics.DrawString("-" + System.Convert.ToString(Cfe.InfCFe.Det[i].Prod.VDesc), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                        Linha += FonteNormal.Height + 5;
                    }
                    else if (Cfe.InfCFe.Det[i].Prod.VDesc > 0) //verifica se há acrescimos no cupom de venda
                    {
                        e.Graphics.DrawString("acréscimo sobre o item", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                        e.Graphics.DrawString("+" + System.Convert.ToString(Cfe.InfCFe.Det[i].Prod.VOutro), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                        Linha += FonteNormal.Height + 5;
                    }
                }

            }
            catch (Exception)
            {
                Erro = "Erro ao imprimir os produtos";
            }
        }

        private void ImprimirPagamento(System.Drawing.Printing.PrintPageEventArgs e)
        {
            decimal TotalDesAcres = new decimal();
            decimal Totalbruto = new decimal();
            try
            {
                //imprimir os totais

                Totalbruto = (Cfe.InfCFe.Total.VCFe + Cfe.InfCFe.Total.DescAcrEntr.VDescSubtot) - Cfe.InfCFe.Total.DescAcrEntr.VAcresSubtot;

                e.Graphics.DrawString("Total bruto dos itens", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                e.Graphics.DrawString(System.Convert.ToString(Totalbruto), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                Linha += FonteNormal.Height + 5;

                if (Cfe.InfCFe.Total.DescAcrEntr.VDescSubtot > 0 & Cfe.InfCFe.Total.DescAcrEntr.VAcresSubtot > 0)
                {
                    TotalDesAcres = Cfe.InfCFe.Total.DescAcrEntr.VDescSubtot + Cfe.InfCFe.Total.DescAcrEntr.VAcresSubtot;
                    e.Graphics.DrawString("Total de desconto/acréscimo sobre item", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    e.Graphics.DrawString("-/+" + System.Convert.ToString(TotalDesAcres), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                    Linha += FonteNormal.Height + 5;
                }
                else if (Cfe.InfCFe.Total.DescAcrEntr.VDescSubtot > 0)
                {
                    TotalDesAcres = Cfe.InfCFe.Total.DescAcrEntr.VDescSubtot;
                    e.Graphics.DrawString("Total de desconto sobre item", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    e.Graphics.DrawString("-" + System.Convert.ToString(TotalDesAcres), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                    Linha += FonteNormal.Height + 5;
                }
                else if (Cfe.InfCFe.Total.DescAcrEntr.VAcresSubtot > 0)
                {
                    TotalDesAcres = Cfe.InfCFe.Total.DescAcrEntr.VAcresSubtot;
                    e.Graphics.DrawString("Total de acréscimo sobre item", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    e.Graphics.DrawString("+" + System.Convert.ToString(TotalDesAcres), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                    Linha += FonteNormal.Height + 5;
                }

                Linha += 5;
                e.Graphics.DrawString("TOTAL R$", FonteNegrito, Brushes.Black, 5, Linha, new StringFormat());
                e.Graphics.DrawString(System.Convert.ToString(Cfe.InfCFe.Total.VCFe), FonteNegrito, Brushes.Black, 220, Linha, new StringFormat());
                Linha += FonteNormal.Height + 10;

                for (var i = 0; i <= Cfe.InfCFe.Pagto.Pagamentos.Count - 1; i++)
                {

                    string PagamentoTipo = "";

                    switch (Cfe.InfCFe.Pagto.Pagamentos[i].CMp)
                    {
                        case (ACBr.Net.Sat.CodigoMP)0:
                            PagamentoTipo = "Dinheiro";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)1:
                            PagamentoTipo = "Cheque";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)2:
                            PagamentoTipo = "Cartão de Crédito";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)3:
                            PagamentoTipo = "Cartão de Débito";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)4:
                            PagamentoTipo = "Crédito Loja";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)5:
                            PagamentoTipo = "Vale Alimentação";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)6:
                            PagamentoTipo = "Vale Refeição";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)7:
                            PagamentoTipo = "Vale Presente";
                            break;
                        case (ACBr.Net.Sat.CodigoMP)8:
                            PagamentoTipo = "Vale Combustível";
                            break;
                        default:
                            PagamentoTipo = "Outros";
                            break;
                    }

                    e.Graphics.DrawString(PagamentoTipo, FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    e.Graphics.DrawString(System.Convert.ToString(Cfe.InfCFe.Pagto.Pagamentos[i].VMp), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                    Linha += FonteNormal.Height + 5;
                }
                if (Cfe.InfCFe.Pagto.VTroco > 0)
                {
                    e.Graphics.DrawString("Troco:", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                    e.Graphics.DrawString(System.Convert.ToString(Cfe.InfCFe.Pagto.VTroco), FonteNormal, Brushes.Black, 220, Linha, new StringFormat());
                    Linha += FonteNormal.Height + 5;
                }
            }
            catch
            {
                Erro = "Erro ao imprimir o pagamento";
            }

        }

        private void ImprimirCodigos(System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                string[] Barcodestring = new string[2];
                string docdest = "";

                Barcodestring[0] = Cfe.InfCFe.Id.Substring(3, 22);
                Barcodestring[1] = Cfe.InfCFe.Id.Substring(Cfe.InfCFe.Id.Length - 22, 22);

                if (!string.IsNullOrEmpty(Cfe.InfCFe.Dest.CPF))
                {
                    docdest = Cfe.InfCFe.Dest.CPF;
                }
                else if (!string.IsNullOrEmpty(Cfe.InfCFe.Dest.CNPJ))
                {
                    docdest = Cfe.InfCFe.Dest.CNPJ;
                }

                QrcodeX = QrEncoder.Encode(Barcodestring[0] + Barcodestring[1] + "|" + String.Format(Cfe.InfCFe.Ide.DhEmissao.ToString(), "yyyyMMddHHmmss") + "|" + System.Convert.ToString(Cfe.InfCFe.Total.VCFe).Replace(",", ".") + "|" + docdest + "|" + Cfe.InfCFe.Ide.AssinaturaQrcode);

                GraphicsRenderer gRenderer = new GraphicsRenderer(new FixedModuleSize(2, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                MemoryStream ms = new MemoryStream();
                FileStream file = new FileStream(Application.StartupPath + "\\QR.png", FileMode.Create, FileAccess.Write);
                gRenderer.WriteToStream(QrcodeX.Matrix, ImageFormat.Png, file);
                file.Close();

                Image imgQrcode = Image.FromFile(Application.StartupPath + "\\QR.png");

                Linha += 20;
                e.Graphics.DrawString("SAT Nº" + System.Convert.ToString(Cfe.InfCFe.Ide.NSerieSAT), FonteTitulo, Brushes.Black, 70, Linha, new StringFormat());
                Linha += FonteNormal.Height + 5;
                e.Graphics.DrawString(Cfe.InfCFe.Ide.DhEmissao.ToString(), FonteSubtitulo, Brushes.Black, 70, Linha, new StringFormat());
                Linha += FonteNormal.Height + 5;
                e.Graphics.DrawString(Cfe.InfCFe.Id.Substring(3, Cfe.InfCFe.Id.Length - 3), FonteNormal, Brushes.Black, 5, Linha, new StringFormat());

                Linha += 20;
                e.Graphics.DrawImage(barcode.Encode(BarcodeLib.TYPE.CODE128C, Barcodestring[0], 250, 30), 5, System.Convert.ToInt32(Linha));
                Linha += 40;
                e.Graphics.DrawImage(barcode.Encode(BarcodeLib.TYPE.CODE128C, Barcodestring[1], 250, 30), 5, System.Convert.ToInt32(Linha));
                Linha += 40;
                e.Graphics.DrawImage(imgQrcode, 30, System.Convert.ToInt32(Linha));

                Linha += 240;
                e.Graphics.DrawString("Consulte o QR Code pelo aplicativo - De olho na nota,", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
                Linha += FonteNormal.Height;
                e.Graphics.DrawString("disponível na AppStore(Apple) e PlayStore (Android)", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.GetBaseException().ToString());
                Erro = "Erro ao imprimir Código de barras e QrCode";

            }

        }

        private void ImprimirImpostos(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //impostos
            e.Graphics.DrawString("Valor aproximado dos tributos deste cupom", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
            Linha += FonteNormal.Height;
            e.Graphics.DrawString(Cfe.InfCFe.InfAdic.InfCpl, FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
            Linha += FonteNormal.Height;
            e.Graphics.DrawString("(conforme Lei Fed. 12.741/2012) Fonte : IBPT ", FonteNormal, Brushes.Black, 5, Linha, new StringFormat());
            Linha += FonteNormal.Height + 2;
        }

        private void ImprimirCancelamento(System.Drawing.Printing.PrintPageEventArgs e)
        {

            //dados do SAT Cancelamento
            Linha += 10;
            e.Graphics.DrawString("Extrato Nº " + String.Format(Cfe.InfCFe.Ide.NCFe.ToString(), "000000"), FonteTitulo, Brushes.Black, 70, Linha, new StringFormat());
            Linha += FonteNormal.Height + 5;
            e.Graphics.DrawString("CUPOM FISCAL ELETRÔNICO - SAT", FonteTitulo, Brushes.Black, 5, Linha, new StringFormat());
            Linha += FonteTitulo.Height;
            e.Graphics.DrawString("CANCELAMENTO", FonteTitulo, Brushes.Black, 70, Linha, new StringFormat());
            Linha += FonteTitulo.Height + 10;
            e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));
            e.Graphics.DrawString("DADOS DO CUPOM FISCAL CANCELADO", FonteNormal, Brushes.Black, 30, Linha, new StringFormat());

            //dados do destinatário
            if (!ReferenceEquals(Cfe.InfCFe.Dest.CNPJ, null))
            {
                Linha += 25;
                e.Graphics.DrawString("CPF/CNPJ do Consumidor:" + Cfe.InfCFe.Dest.CNPJ, FonteNormal, Brushes.Black, 15, Linha, new StringFormat());
            }
            else if (!ReferenceEquals(Cfe.InfCFe.Dest.CPF, null))
            {
                Linha += 25;
                e.Graphics.DrawString("CPF/CNPJ do Consumidor:" + Cfe.InfCFe.Dest.CPF, FonteNormal, Brushes.Black, 15, Linha, new StringFormat());
            }

            //linha separatória
            Linha += FonteNormal.Height;

            ImprimirProdutos(e);

            Linha += 25;

            e.Graphics.DrawString("TOTAL R$", FonteNegrito, Brushes.Black, 5, Linha, new StringFormat());
            e.Graphics.DrawString(System.Convert.ToString(Cfe.InfCFe.Total.VCFe), FonteNegrito, Brushes.Black, 220, Linha, new StringFormat());

            Linha += 25;

            e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));

        }

        //Layout da(s) página(s) a imprimir
        private void PdRelatorios_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //Variaveis das linhas
            Linha = 5;
            LinhaAtual = 0;

            IniciarFontes();

            if (CfeCancelamento)
            {
                ImprimirCancelamento(e);
            }
            else
            {

                ImprimirCabecalho(e);

                e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));

                ImprimirProdutos(e);

                ImprimirPagamento(e);

                ImprimirDadosEntrega(e);

                ImprimirImpostos(e);

                e.Graphics.DrawLine(CanetaDaImpressora, 5, System.Convert.ToInt32(Linha), Bobina, System.Convert.ToInt32(Linha));

            }

            ImprimirCodigos(e);

            e.HasMorePages = false;

        }

    }

}


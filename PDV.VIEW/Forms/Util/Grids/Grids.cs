using DevExpress.DataProcessing;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDV.VIEW.Forms.Util
{
    public class Grids
    {

        public static string GetValorStr(GridView gridView, string fieldName, int rowHandle = -1)
        {
            //
            //Buscará um valor específico na grid recebida e no campo informado na assinatura
            //gridView: a grid em que se quer buscar um dado
            //fieldName: o nome do campo na grid que se quer buscar o vvallor
            //rowHandle: é a linha de onde se quer buscar o valor; se não for informado será a linha selecionada pelo usuário.
            //

    

            try
            {
                if (gridView.FocusedRowHandle < 0)
                    throw new Exception("Nenhuma linha foi selecionada");

                if (rowHandle == -1)
                    rowHandle = gridView.FocusedRowHandle;


                return gridView.GetRowCellValue(rowHandle, fieldName).ToString();//.ToUpper()

                return gridView.GetRowCellValue(rowHandle, fieldName).ToString();

            }
            catch(Exception exception)
            {
               var msg = $"Desculpe! Não foi possível buscar o valor selecionado no campo '{fieldName}'. {exception.Message}.";
               throw new Exception(msg);
            }
            
        }

        public static int GetValorInt(GridView gridView, string fieldName, int rowHandle = -1)
        {
            try
            {
                return Convert.ToInt32(GetValorStr(gridView, fieldName, rowHandle));

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static decimal GetValorDec(GridView gridView, string fieldName, int rowHandle = -1)
        {
            try
            {
                

                return Convert.ToDecimal(GetValorStr(gridView, fieldName, rowHandle));//.ToUpper()

                return Convert.ToDecimal(GetValorStr(gridView, fieldName, rowHandle));

            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public static void FormatGrid(ref GridView gridView, string firstColumnCaption = "ID")
        {
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                var key = gridView.Columns[i].FieldName;

                try
                {
                    var value = GetCaptionsMap().Where(m => m.Key.ToLower() == key.ToLower()).Select(m => m.Value).Single();

                    gridView.Columns[i].Caption = value.ToUpper();
                }
                catch (InvalidOperationException)
                {
                    gridView.Columns[i].Caption = key.ToUpper();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                
            }

            if (gridView.Columns.Count > 0)
            {
                gridView.Columns[0].Caption = firstColumnCaption;
                FormatColumnType(ref gridView, gridView.Columns[0].FieldName, GridFormats.Count);
            }
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.BestFitColumns();

        }

        private static Dictionary<string, string> GetCaptionsMap()
        {
            return new Dictionary<string, string>()
            {
                { "IDVENDA", "ID VENDA" },
                { "IDNFE", "ID NFE" },
                { "NUMERO", "NÚMERO" },
                { "DATAEMISSAO", "DATA DE EMISSÃO" },
                { "TOTALNFE", "TOTAL DA NFE" },
                { "IDMOVIMENTOFISCAL", "ID MF" },
                { "XMOTIVO", "RETORNO DA SEFAZ" },
                { "IDITEMVENDA", "ID ITEM DE VENDA" },
                { "DESCRICAO", "DESCRIÇÃO" },
                { "DESCRICAOITEM", "DESCRIÇÃO DO ITEM" },
                { "DESCONTOVALOR", "VALOR DE DESCONTO" },
                { "VALORUNITARIOITEM", "VALOR UNITÁRIO DO ITEM" },
                { "VALORTOTALITEM", "VALOR TOTAL DO ITEM" },
                { "CODIGOITEM", "CÓDIGO DO ITEM" },
                { "IDPEDIDOCOMPRA", "ID COMPRA" },
                { "VALORUNITARIO", "VALOR UNITÁRIO" },
                { "USUARIO", "USUÁRIO" },
                { "DATACADASTRO", "DATA" },
                { "VALORTOTAL", "TOTAL" },
                { "HORA", "HORA" },
                { "CODIGO", "CÓDIGO" },
                { "NACIONALFEDERAL", "NACIONAL FEDERAL" },
                { "IMPORTADOSFEDERAL", "IMPORTADOS FEDERAL" },
                { "VIGENCIAFIM", "FIM VIGÊNCIA" },
                { "VIGENCIAINICIO", "INÍCIO VIGÊNCIA" },
                { "DATAENTREGA", "DATA DE ENTREGA" },
                { "DATACANCELAMENTO", "DATA DE CANCELAMENTO" },
                { "TIPODEOPERACAO", "OPERAÇÃO" },
                { "TIPODEFRETE", "TIPO DE FRETE" },
                { "CONTROLARESTOQUE", "CONTROLAR ESTOQUE" },
                { "GERARFINANCEIRO", "GERAR FINANCEIRO" },
                { "LIMITECREDITO", "LIMITE DE CRÉDITO" },
                { "PERMITEESTOQUENEGATIVO", "PERMITE ESTOQUE NEGATIVO" },
                { "TIPODEMOVIMENTO", "TIPO DE MOVIMENTO" },
                { "SERIE", "SÉRIE" },
                { "DOCUMENTO", "CPF/CNPJ" },
                { "NUMERODOCUMENTO", "DOC" },
                { "RAZAOSOCIAL", "RAZÃO SOCIAL" },
                { "INSCRICAOESTADUAL", "IE" },
                { "COD", "CÓD" },
                { "VENDEDOR", "VENDEDOR" },
                { "EAN", "C. DE BARRAS" },
                { "SALDOESTOQUE", "ESTOQUE" },
                { "VALORCUSTO", "PREÇO DE COMPRA" },
                { "VALORVENDA", "PREÇO DE VENDA" },
                { "VALORVENDAPRAZO", "VALOR DE VENDA A PRAZO" },
                { "BANDEIRACARTAO", "BANDEIRA DE CARTÃO" },
                { "IDENTIFICACAO", "IDENTIFICAÇÃO" },
                { "AGENCIA", "AGÊNCIA" },
                { "TITULO", "TÍTULO" },
                { "MARCADEVEICULO", "MARCA DE VEÍCULO" },
                { "MARCADEPRODUTO", "MARCA DE PRODUTO" },
                { "OPERACAO", "OPERAÇÃO" },
                { "EMAIL", "E-MAIL" },
                { "OBSERVACAO", "OBSERVAÇÃO" },
                { "DATAINCLUSAO", "DATA DE INCLUSÃO" },
                { "IDUSUARIO", "ID DO USUÁRIO" },
                { "TRANSPORTADORAID", "ID DA TRANSPORTADORA" },
                { "TRANSPORTADORANOME", "NOME DA TRANSPORTADORA" },
                { "VEICULOID", "ID DO VEÍCULO" },
                { "VEICULODESCRICAO", "DESCRIÇÃO DO VEÍCULO" },
                { "MOTORISTAID", "ID DO MOTORISTA" },
                { "MOTORISTANOME", "NOME DO MOTORISTA" },
                { "TOTALITENS", "TOTAL DE ITENS" },
                { "DATAFATURAMENTO",  "DATA DE FATURAMENTO" },
                { "IDROMANEIO", "ID DO ROMANEIO" },
                { "IDPRODUTO", "ID DO PRODUTO" },
                { "DESCONTOPORCENTAGEM", "PORCENTAGEM DE DESCONTO" },
                { "PRECOVENDA", "PREÇO DE VENDA" },
                { "CODIGODEBARRAS", "CÓDIGO DE BARRAS" },
                { "TIPODEVENDA", "TIPO" },
                { "PARAVENDER", "PARA VENDER" },
                { "MODIFICACAO", "MODIFICAÇÃO" },
                { "SITUACAO", "SITUAÇÃO" },
                { "FORMAPAGAMENTO", "FORMA DE PAGAMENTO" },
                { "DATAMODIFICACAO", "DATA DE MODIFICAÇÃO" },
                { "HORAMODIFICACAO", "HORA DE MODIFICAÇÃO" },
                { "EMISSAO", "EMISSÃO" },
                { "UNIDADEDEMEDIDASIGLA", "UNIDADE DE MEDIDA(SIGLA)" },
                { "MOTIVODECANCELAMENTO", "MOTIVO DE CANCELAMENTO" },
                { "IDCLIENTE", "ID DO CLIENTE" },
                { "IDVENDEDOR", "ID DO VENDEDOR" },
                { "CAIXAID", "ID DO CAIXA" },
                { "VALORFECHAMENTOCAIXA", "VALOR DE FECHAMENTO"},
                { "VALORCAIXA", "VALOR DE ABERTURA" },
                { "NUMEROCAIXA", "NÚMERO DO CAIXA" },
                { "DATAABERTURACAIXA", "DATA DE ABERTURA" },
                { "TOTALCUSTO", "TOTAL CUSTO" },
                { "IDCONTARECCOBRANCA", "ID CONTA RECEBER COBRANÇA" },
                { "VALORDUPLICATA", "VALOR DA DUPLICATA" },
                { "EMISSAOTITULO", "EMISSÃO TÍTULO" },
                { "VENCIMENTOTITULO", "VENCIMENTO TÍTULO" },
                { "VENCIMENTODUPLICATA", "VENCIMENTO DUPLICATA" },
                { "EMISSAODUPLICATA", "EMISSÃO DUPLICATA" },
                { "SITUACAOTITULO", "SITUAÇÃO TÍTULO" },
                { "STATUSDUPLICATA", "STATUS DUPLICATA" },
                { "SAIDA", "SAÍDA" },
                { "CDEBARRAS", "C. DE BARRAS" },
                {"IDCONTARECEBER","IDCONTARECEBER"},
                {"IDCONTABANCARIA","IDCONTABANCARIA"},
                {"IDCENTROCUSTO","IDCENTROCUSTO"},
                {"IDFORMADEPAGAMENTO","IDFORMADEPAGAMENTO"},
                {"IDHISTORICOFINANCEIRO","IDHISTORICOFINANCEIRO"},
                {"PARCELA","PARCELA"},
                {"VENCIMENTO","VENCIMENTO"},
                {"COMPLMHISFIN","COMPLMHISFIN"},
                {"FLUXO","FLUXO"},
                {"VALOR","VALOR"},
                {"ORIGEM","ORIGEM"},
                {"MULTA","MULTA"},
                {"JUROS","JUROS"},
                {"DESCONTO","DESCONTO"},
                {"SALDO","SALDO"},
                {"IDCONTARECEBERRENEGOCIACAO","IDCONTARECEBERRENEGOCIACAO"},
                {"CHAVEERP","CHAVEERP"},
                {"PAGAMENTO","PAGAMENTO"},
                {"ULTIMAMODIFICACAO","ULTIMAMODIFICACAO"},
                {"IDORDEMDESERVICO","IDORDEMDESERVICO"},
                {"CODVENDEDOR","CODVENDEDOR"},
                {"LOGRADOURO","LOGRADOURO"},
                {"TIPO","TIPO"},
                {"CEP","CEP"},
                {"TELEFONE","TELEFONE"},
                {"CELULAR","CELULAR"},
                {"CIDADE","CIDADE"},
                {"UF","UF"},
                {"ATIVO","ATIVO"},
                {"BAIRRO","BAIRRO"},
                {"LIMITEDECREDITO","LIMITEDECREDITO"}
                
            };
        }
        public static void FormatColumnType(ref GridView gridView, string columnIndex, GridFormats format)
        {
            try
            {
                var column = gridView.Columns.Where(c => c.FieldName.ToLower() == columnIndex.ToLower()).Single();
                switch (format)
                {
                    case GridFormats.Finance:                        
                        gridView.Columns[column.FieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView.Columns[column.FieldName].DisplayFormat.FormatString = "c2";
                    break;
                    case GridFormats.VisibleFalse:
                        gridView.Columns[column.FieldName].Visible = false;
                    break;
                    case GridFormats.Count:
                        gridView.Columns[column.FieldName].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        gridView.Columns[column.FieldName].SummaryItem.DisplayFormat = "Registros: {0}";
                        break;
                    case GridFormats.SumFinance:
                        gridView.Columns[column.FieldName].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView.Columns[column.FieldName].SummaryItem.DisplayFormat = "Total: R${0:n2}";                 
                    break;
                    case GridFormats.Sum:
                        gridView.Columns[column.FieldName].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView.Columns[column.FieldName].SummaryItem.DisplayFormat = "Soma: {0}";
                    break;
                }
            }

            catch(NullReferenceException exception)
            {
                var msg = $"Pode ser que o nome do campo ('{columnIndex}'), enviado para formatação de uma coluna na grid, seja incorreto. {exception.Message}";
                throw new Exception(msg);
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void FormatColumnType(ref GridView gridView, List<string> columnsIndexList, GridFormats format)
        {
            foreach (var index in columnsIndexList)
                FormatColumnType(ref gridView, index, format);
        }

    }
}

using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesSaldoEstoqueInicial
    {
        public static bool Salvar(SaldoEstoqueInicial Saldo, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO SALDOESTOQUEINICIAL
                                       (IDSALDOESTOQUEINICIAL, IDALMOXARIFADO, IDPRODUTO, DATACADASTRO, QUANTIDADE, VALOR)
                                     VALUES
                                       (@IDSALDOESTOQUEINICIAL, @IDALMOXARIFADO, @IDPRODUTO, @DATACADASTRO, @QUANTIDADE, @VALOR)";
                        oSQL.ParamByName["DATACADASTRO"] = Saldo.DataCadastro;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE SALDOESTOQUEINICIAL
                                       SET IDALMOXARIFADO = @IDALMOXARIFADO,
                                           IDPRODUTO = @IDPRODUTO,
                                           QUANTIDADE = @QUANTIDADE,
                                           VALOR = @VALOR
                                       WHERE IDSALDOESTOQUEINICIAL = @IDSALDOESTOQUEINICIAL";
                        break;
                }
                oSQL.ParamByName["IDSALDOESTOQUEINICIAL"] = Saldo.IDSaldoEstoqueInicial;
                oSQL.ParamByName["IDALMOXARIFADO"] = Saldo.IDAlmoxarifado;
                oSQL.ParamByName["IDPRODUTO"] = Saldo.IDProduto;
                oSQL.ParamByName["QUANTIDADE"] = Saldo.Quantidade;
                oSQL.ParamByName["VALOR"] = Saldo.Valor;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDSaldoEstoqueInicial)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM SALDOESTOQUEINICIAL WHERE IDSALDOESTOQUEINICIAL = @IDSALDOESTOQUEINICIAL";
                oSQL.ParamByName["IDSALDOESTOQUEINICIAL"] = IDSaldoEstoqueInicial;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDSaldoEstoqueInicial)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM SALDOESTOQUEINICIAL WHERE IDSALDOESTOQUEINICIAL = @IDSALDOESTOQUEINICIAL";
                oSQL.ParamByName["IDSALDOESTOQUEINICIAL"] = IDSaldoEstoqueInicial;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static SaldoEstoqueInicial GetSaldo(decimal IDSaldoEstoqueInicial)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDSALDOESTOQUEINICIAL,
IDALMOXARIFADO,
IDPRODUTO,
DATACADASTRO,
QUANTIDADE,
VALOR FROM SALDOESTOQUEINICIAL WHERE IDSALDOESTOQUEINICIAL = @IDSALDOESTOQUEINICIAL";
                oSQL.ParamByName["IDSALDOESTOQUEINICIAL"] = IDSaldoEstoqueInicial;
                oSQL.Open();
                return EntityUtil<SaldoEstoqueInicial>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetSaldos(string Produto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT SALDOESTOQUEINICIAL.DATACADASTRO,
                                     ALMOXARIFADO.DESCRICAO AS ALMOXARIFADO,
                                     PRODUTO.DESCRICAO,
                                     SALDOESTOQUEINICIAL.QUANTIDADE,
                                     SALDOESTOQUEINICIAL.VALOR,
                                     SALDOESTOQUEINICIAL.IDSALDOESTOQUEINICIAL,
                                     SALDOESTOQUEINICIAL.IDALMOXARIFADO,
                                     SALDOESTOQUEINICIAL.IDPRODUTO
                              FROM SALDOESTOQUEINICIAL
                                INNER JOIN PRODUTO ON (SALDOESTOQUEINICIAL.IDPRODUTO = PRODUTO.IDPRODUTO)
                                INNER JOIN ALMOXARIFADO ON (SALDOESTOQUEINICIAL.IDALMOXARIFADO = ALMOXARIFADO.IDALMOXARIFADO)
                              WHERE UPPER(PRODUTO.DESCRICAO) LIKE UPPER('%{Produto}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}

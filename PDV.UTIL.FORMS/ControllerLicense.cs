using DueLicence;
using Newtonsoft.Json;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS
{
  
    public static class ControllerLicense
    {
        static ControllerLicense()
        {
                    
    }
        public static async Task<List<ClienteInfo>> BuscarLicencaAPI(string CNPJ)
        {
            try
            {
                IniFile iniFile = new IniFile(ContextoUtil.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
                HttpClient client = new HttpClient();
                string url = iniFile.GetValue("Conexao_PDV", "apilicense") + CNPJ;
                var response = await client.GetStringAsync(url);
                List<ClienteInfo> cliente = JsonConvert.DeserializeObject<List<ClienteInfo>>("[" + response + "]").ToList();
                return cliente;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                return null;

            }
        }


        public static bool  VerificaInternet()
        {
            return ConexaoInternet.ExisteConexao();
        }

        public static async Task<bool> VerificarBloqueiLicença()
        {
            try
            {
                string DataValidade = "";
                string DataLocal = "";
                Emitente _Emitente = FuncoesEmitente.GetEmitente();
                if (VerificaInternet())
                {
                    ContextoUtil db = new ContextoUtil();
                    List<ClienteInfo> listcliente = await BuscarLicencaAPI(_Emitente.CNPJ);
                    if (listcliente[0] != null)
                    {
                        if (!listcliente[0].Ativo)
                        {
                         
                            throw new Exception("Cliente não está ativo!");
                        }
                        else
                        {
                             DataValidade = listcliente[0].DataValidadeCrypto;

                             string DataValidadeDecr = DueLicence.Crypto.Decrypt(DataValidade);

                            DataLocal = DueLicence.Crypto.Encrypt(DateTime.Now.ToString());

                            if (string.IsNullOrEmpty(DataValidade))
                            {
                                throw new Exception("Chave não esta cadastrada");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Cliente não está cadastrado no portal de licença!");
                    }
                }
                else
                {
                    DataValidade = _Emitente.chaveerp;
                    DataLocal = _Emitente.datalocal;
                }
                FuncoesEmitente.AtualizarChave(DataValidade, DataLocal);
                _Emitente = FuncoesEmitente.GetEmitente();
                DateTime datavalidade = DateTime.Now;
                DateTime datalocal = DateTime.Now;
                DateTime datasistema = DateTime.Now;

                if (!string.IsNullOrEmpty(_Emitente.chaveerp) && !string.IsNullOrEmpty(_Emitente.datalocal))
                {
                    datavalidade = Convert.ToDateTime(DueLicence.Crypto.Decrypt(_Emitente.chaveerp));
                    datalocal = DateTime.Now;//Convert.ToDateTime(DueLicence.Crypto.Decrypt(_Emitente.datalocal));


                    FuncoesGlobal.ValidadeSistema = datavalidade;
                    FuncoesGlobal.Empresa = _Emitente.NomeFantasia;
                    FuncoesGlobal.CNPJ = _Emitente.CNPJ;
                    //Datas Atuais
                    int DiaAtual = DateTime.Now.Day;
                    int MesAtual = DateTime.Now.Month;
                    int AnoAtual = DateTime.Now.Year;

                    //Datas Vencimento
                    int DiaVencimento = datavalidade.Day;
                    int MesVencimento = datavalidade.Month;
                    int AnoVencimento = datavalidade.Year;

                    TimeSpan diferencia = (datavalidade.Date) - (datalocal.Date);
                    int diferenciaDias = int.Parse(diferencia.Days.ToString());
                    int totaldias = diferenciaDias;
                    if (totaldias <= 5 && totaldias > 0)
                    {
                        MessageBox.Show(
                            "A validade do sistema se encerra em " + totaldias + " dia(s). " +
                            "Atualize e continue ultilizando a praticidade o Rootsys ERP pode oferecer.", 
                            "Licença", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning
                        );
                    }
                }
                else
                {
                    throw new Exception("Chave ou data local não foi preenchida corretamente no banco de dados!");
                }

                if (datavalidade.Date < datalocal.Date || datavalidade.Date < datasistema.Date || datasistema.Date != datalocal.Date)
                {
                    throw new Exception("Sua validade expirou!");
                }
                else
                {                    
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }        

        }

    }
}

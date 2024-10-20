using PDV.DAO.Custom.Configuracoes;
using PDV.DAO.DB.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.DAO.DB.Controller
{
    public enum TipoConfiguracao
    {
        StartIni,
        XML
    }

    public enum TipoCriptografia
    {
        Padrao,
        MD5
    }

    public class Controlador
    {

        #region Fields
        public Dictionary<int, Conexao> Pool { get; set; }
        public static IniFile IniFile { get; set; }

        public DataTable dtConexoesUsuario { get; set; }

        public static int IDConexaoPrimaria
        {
            get { return -1111; }
        }

        public string _DirArquivoConfiguracao { get; set; }
        public TipoConfiguracao _TipoConfiguracao { get; set; }
        public TipoCriptografia _TipoCriptografia { get; set; }
        #endregion

        #region Constructor
        public Controlador(TipoConfiguracao tipoConfiguracao, TipoCriptografia tipoCriptografia = TipoCriptografia.Padrao)
        {
            if (Pool == null)
                Pool = new Dictionary<int, Conexao>();

            this._TipoConfiguracao = tipoConfiguracao;
            this._TipoCriptografia = tipoCriptografia;
        }

        ~Controlador()
        {
            this.Pool = null;
            this._DirArquivoConfiguracao = null;
            if (this.dtConexoesUsuario != null)
                this.dtConexoesUsuario.Dispose();
            this.dtConexoesUsuario = null;
        }
        #endregion

        #region Inicializa Arquivo De Configuração
        public void Inicializa(string dir)
        {
            IniFile = new IniFile(dir);
            _DirArquivoConfiguracao = dir;
        }
        #endregion

        #region ConexaoPrimaria
        public void IniciaConexaoPrimaria(string Identificador)
        
        {
            AdicionaConexao_ArquivoConfiguracao(IDConexaoPrimaria, Identificador);
            Connect(IDConexaoPrimaria);
        }


        public void IniciaConexaoPrimaria_Teste(string Identificador, string servidor,string banco, string usuario,string senha)

        {
            AdicionaConexao_ArquivoConfiguracao_Teste(IDConexaoPrimaria, Identificador, servidor,banco,usuario,senha);
            Connect(IDConexaoPrimaria);
        }




        public void Conectar(int IDConexao)
        {
            Connect(IDConexao);
        }

        public void DesconectarConexaoPrimaria()
        {
            this.Disconnect(IDConexaoPrimaria);
        }
        public void DesconectarConexao(int IDConexao)
        {
            this.Disconnect(IDConexao);
        }
        
        public CFG_PDV GetConfiguracaoPDV()
        {
            return new CFG_PDV
            {
                SerieNFCe = Convert.ToInt32(IniFile.GetValue("Configuracoes_PDV", "serie_nfce", "1")),
                NomeSequenceNFCe = IniFile.GetValue("Configuracoes_PDV", "nomesequence_nfce", "PDV_01"),

                SerieNFe = Convert.ToInt32(IniFile.GetValue("Configuracoes_PDV", "serie_nfe", "1")),
                NomeSequenceNFe = IniFile.GetValue("Configuracoes_PDV", "nomesequence_nfe", "NFE_01"),

                SerieMDFe = Convert.ToInt32(IniFile.GetValue("Configuracoes_PDV", "serie_mdfe", "1")),
                NomeSequenceMDFe = IniFile.GetValue("Configuracoes_PDV", "nomesequence_mdfe", "MDFE_01")
            };
        }

        public void AdicionaConexao_ArquivoConfiguracao(int IDConexao, string Identificador)
        {
            string vsSGBD = IniFile.GetValue(Identificador, "sgbd").ToUpper();
            string vsUsuario = IniFile.GetValue(Identificador, "usuario");
            string vsSenha =
                this._TipoCriptografia == TipoCriptografia.Padrao ?
                Criptografia.DecodificaSenha(IniFile.GetValue(Identificador, "senha")) :
               CriptografiaMD5.CriptografiaMD5.DecodificaSenha(vsUsuario, IniFile.GetValue(Identificador, "senha"));

            string pgServer = IniFile.GetValue(Identificador, "servidor");
            string pgPorta = IniFile.GetValue(Identificador, "porta", "5432");
            string pgDatabase = IniFile.GetValue(Identificador, "banco");
            string pgMaxPoolSize = IniFile.GetValue(Identificador, "max_pool_size", "100");
            string pgMinPoolSize = Convert.ToInt32(pgMaxPoolSize) >= 10 ? "10" : Convert.ToInt32(pgMaxPoolSize).ToString();
            //string strPostgres = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};MaxPoolSize={5};MinPoolSize={6};CommandTimeout=0;TIMEOUT=60;",
            //                                      pgServer, pgPorta, pgDatabase, vsUsuario, vsSenha, pgMaxPoolSize, pgMinPoolSize);

            string strPostgres = String.Format("Data Source={0},{1};Initial Catalog={2};User Id={3};Password={4};Max Pool Size={5};Min Pool Size={6};MultipleActiveResultSets=True;Connection Timeout=30;Trusted_Connection=True;",
                                         pgServer, pgPorta, pgDatabase, vsUsuario, vsSenha, pgMaxPoolSize, pgMinPoolSize);


            if (!string.IsNullOrEmpty(pgDatabase))
                this.AddConexao(IDConexao, strPostgres);
        }



        public void AdicionaConexao_ArquivoConfiguracao_Teste(int IDConexao, string Identificador, string servidor, string banco, string usuario, string senha)
        {
            string vsSGBD = IniFile.GetValue(Identificador, "sgbd").ToUpper();
            string vsUsuario = usuario;
            string vsSenha = senha;

            string pgServer = servidor;
            string pgPorta = IniFile.GetValue(Identificador, "porta", "5432");
            string pgDatabase = banco;
            string pgMaxPoolSize = IniFile.GetValue(Identificador, "max_pool_size", "100");
            string pgMinPoolSize = Convert.ToInt32(pgMaxPoolSize) >= 10 ? "10" : Convert.ToInt32(pgMaxPoolSize).ToString();
            //string strPostgres = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};MaxPoolSize={5};MinPoolSize={6};CommandTimeout=0;TIMEOUT=60;",
            //                                      pgServer, pgPorta, pgDatabase, vsUsuario, vsSenha, pgMaxPoolSize, pgMinPoolSize);

            string strPostgres = String.Format("Data Source={0},{1};Initial Catalog={2};User Id={3};Password={4};Max Pool Size={5};Min Pool Size={6};MultipleActiveResultSets=True;Connection Timeout=3;Trusted_Connection=True;",
                                         pgServer, pgPorta, pgDatabase, vsUsuario, vsSenha, pgMaxPoolSize, pgMinPoolSize);


            if (!string.IsNullOrEmpty(pgDatabase))
                this.AddConexao(IDConexao, strPostgres);
        }





        public bool ConexaoPrimariaEstaAtiva()
        {
            foreach (KeyValuePair<int, Conexao> conn in Pool)
                if (conn.Key == IDConexaoPrimaria)
                    return conn.Value.Connection.State == ConnectionState.Open;

            return false;
        }

        public bool ConexaoEstaAtiva(int IDConexao)
        {
            foreach (KeyValuePair<int, Conexao> conn in Pool)
                if (conn.Key == IDConexao)
                    return conn.Value.Connection.State == ConnectionState.Open;

            return false;
        }

        #endregion

        #region Adiciona Conexão
        public void AddConexao(int IDConexao, string ConnectionString)
        {
            if (!ExisteConexao(IDConexao))
                Pool.Add(IDConexao, new Conexao(IDConexao, ConnectionString));
        }

        public void AddConexao(DataRow drConexao)
        {
            int IDConexao = Convert.ToInt32(drConexao["ID_CONEXAO"]);

            if (!ExisteConexao(IDConexao))
                Pool.Add(IDConexao, new Conexao(drConexao));
        }
        #endregion

        #region Remove Conexão
        public void RemoveConexao(int IDConexao)
        {
            if (!ExisteConexao(IDConexao))
                return;

            try
            {
                Disconnect(IDConexao);
            }
            catch { }
            Pool.Remove(IDConexao);
        }
        #endregion

        #region ExisteConexao
        public bool ExisteConexao(int viIDConexao)
        {
            return Pool.ContainsKey(viIDConexao);
        }
        #endregion

        #region BeginTransaction | Commit | Rollback
        public void BeginTransaction(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].BeginTransaction();
        }

        public bool InTransaction(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].Transaction != null;
            return false;
        }

        public bool IsConnected(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                return Pool[IDConexao].Connection.State == ConnectionState.Open;
            return false;
        }

        public void Commit(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao))
                Pool[IDConexao].Commit(this);
        }

        public void Rollback(int IDConexao)
        {
            if (Pool.ContainsKey(IDConexao) && Pool[IDConexao].Transaction.Connection != null)
                Pool[IDConexao].Rollback();
        }
        #endregion

        #region Connect | Disconnect
        public void Connect(int IDConexao = -1)
        {
            if (IDConexao == -1)
            {
                foreach (KeyValuePair<int, Conexao> conn in Pool)
                    conn.Value.Connect();
            }
            else
            {
                if (Pool.ContainsKey(IDConexao))
                    Pool[IDConexao].Connect();
            }
        }

        public void Disconnect(int IDConexao = -1)
        {
            if (IDConexao == -1)
                foreach (KeyValuePair<int, Conexao> conn in Pool)
                    conn.Value.Disconnect();
            else
                foreach (KeyValuePair<int, Conexao> conn in Pool)
                    if (conn.Key == IDConexao)
                    {
                        conn.Value.Disconnect();
                        break;
                    }
        }
        #endregion    
    }
}

using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_ImportarTabelaIBPT : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_ARQUIVO = string.Empty;
        private List<Ncm> Registros = null;
        private decimal IDUnidadeFederativaEmitente;

        public FCONFIG_ImportarTabelaIBPT()
        {
            InitializeComponent();
            Registros = new List<Ncm>();
            IDUnidadeFederativaEmitente = FuncoesEndereco.GetEndereco(FuncoesEmitente.GetEmitente().IDEndereco).IDUnidadeFederativa.Value;
        }

        private void ovBTN_CarregarArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "*.csv|*.csv";
                openFileDialog1.Title = "*.csv";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    NOME_ARQUIVO = openFileDialog1.FileName;
                    textBox1.Text = NOME_ARQUIVO;

                    progressBar.Maximum = File.ReadAllLines(NOME_ARQUIVO).Length;

                    Thread t = new Thread(StartThead);
                    t.Start();
                }
            }
            catch
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo");
            }
        }

        private void StartThead()
        {
            StreamReader sr = new StreamReader(NOME_ARQUIVO, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage));
            string linha = null;
            string[] linhaseparada = null;

            int QtdLinhas = 0;

            while ((linha = sr.ReadLine()) != null)
            {
                QtdLinhas++;
                linhaseparada = linha.Split(';');
                SetControlPropertyValue(progressBar, "value", QtdLinhas);
                try
                {
                    Registros.Add(new Ncm()
                    {
                        Codigo = Convert.ToDecimal(linhaseparada[0]),
                        Ex = string.IsNullOrEmpty(linhaseparada[1]) ? null : (decimal?)Convert.ToDecimal(linhaseparada[1]),
                        Tipo = Convert.ToDecimal(linhaseparada[2]),
                        Descricao = linhaseparada[3],
                        NacionalFederal = Convert.ToDecimal(linhaseparada[4].Replace(".", ",")),
                        ImportadosFederal = Convert.ToDecimal(linhaseparada[5].Replace(".", ",")),
                        Estadual = Convert.ToDecimal(linhaseparada[6].Replace(".", ",")),
                        Municipal = Convert.ToDecimal(linhaseparada[7].Replace(".", ",")),
                        VigenciaInicio = Convert.ToDateTime(linhaseparada[8]),
                        VigenciaFim = Convert.ToDateTime(linhaseparada[9]),
                        Chave = linhaseparada[10],
                        Versao = linhaseparada[11],
                        Fonte = linhaseparada[12],
                        IDUnidadeFederativa = IDUnidadeFederativaEmitente
                    });
                }
                catch { }
            }
            sr.Close();

          

        }

        private void SalvarInformacoesBancoDados()
        {
            try
            {
              
                int QtdLinhas = 0;
                SetControlPropertyValue(progressBarBanco, "maximum", Registros.Count);

                PDVControlador.BeginTransaction();
                FuncoesNcm.RemoverTodos();
                PDVControlador.Commit();

                foreach (Ncm Tabela in Registros)
                {
                    PDVControlador.BeginTransaction();
                    QtdLinhas++;
                    // if (!FuncoesNcm.SalvarIBPT(Tabela))

                    FuncoesNcm.SalvarIBPT(Tabela);
                            //  throw new Exception("Não foi possível salvar a Tabela.");

                            SetControlPropertyValue(progressBarBanco, "value", QtdLinhas);

                    PDVControlador.Commit();
                }
              
                MessageBox.Show(this, "Tabela salva com sucesso.", "IMPORTAÇÃO DA TABELA DO IBPT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                //PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, "IMPORTAÇÃO DA TABELA DO IBPT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                    if (p.Name.ToUpper() == propName.ToUpper())
                        p.SetValue(oControl, propValue, null);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            /*PDVControlador.BeginTransaction();
             if (!FuncoesNcm.RemoverTodos())
                 throw new Exception("Não foi possível REMOVER a Tabela.");
             PDVControlador.Commit();*/
            SalvarInformacoesBancoDados();
        }
    }
}
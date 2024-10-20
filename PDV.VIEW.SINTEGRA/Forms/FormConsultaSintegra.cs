using DevExpress.XtraEditors;
using MetroFramework;
using PDV.VIEW.SINTEGRA.Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.SINTEGRA.Forms
{
    public partial class FormConsultaSintegra :XtraForm
    {
        public Empresa empresa;
        private ConsultaCNPJReceita consulta;
        private string p;
        private System.ComponentModel.BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        public FormConsultaSintegra(string p)
        {
            InitializeComponent();
            this.p = p;
            backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);

            maskedTxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação                
            maskedTxtCNPJ.Text = p;
            maskedTxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação

            btnAtualizar.Enabled = false;
            btnEnviar.Enabled = false;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void carregarCaptcha()
        {

            consulta = new ConsultaCNPJReceita();
            ttbLetras.Focus();
            Cursor cursor;
            cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Bitmap bit = consulta.GetCaptcha();
            if (bit != null)
                picLetras.Image = bit;
            else
                MessageBox.Show(this, "Não foi possível recuperar a imagem de validação do site da Receita Federal.", Text);
            this.Cursor = cursor;

            btnAtualizar.Enabled = true;
            btnEnviar.Enabled = true;
        }


        private enum Coluna
        {
            RazaoSocial = 0,
            NomeFantasia,

            AtividadeEconomicaPrimaria,
            AtividadeEconomicaSecundaria,

            NumeroDaInscricao,
            MatrizFilial,
            NaturezaJuridica,

            SituacaoCadastral,
            DataSituacaoCadastral,
            MotivoSituacaoCadastral,

            EnderecoLogradouro,
            EnderecoNumero,
            EnderecoComplemento,
            EnderecoCEP,
            EnderecoBairro,
            EnderecoCidade,
            EnderecoEstado,

            ContatoEmail,
            ContatoTel,

            EnteFederativo,
            SituacaoEspecial,
            DataSituacaoEspecial
        };

        private String RecuperaColunaValor(String pattern, Coluna col)
        {
            String S = pattern.Replace("\n", "").Replace("\t", "").Replace("\r", "");

            switch (col)
            {
                case Coluna.RazaoSocial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NOME EMPRESARIAL -->", "<!-- Fim Linha NOME EMPRESARIAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NomeFantasia:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ESTABELECIMENTO -->", "<!-- Fim Linha ESTABELECIMENTO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NaturezaJuridica:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NATUREZA JURÍDICA -->", "<!-- Fim Linha NATUREZA JURÍDICA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.AtividadeEconomicaPrimaria:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ATIVIDADE ECONOMICA -->", "<!-- Fim Linha ATIVIDADE ECONOMICA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.AtividadeEconomicaSecundaria:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ATIVIDADE ECONOMICA SECUNDARIA-->", "<!-- Fim Linha ATIVIDADE ECONOMICA SECUNDARIA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NumeroDaInscricao:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.MatrizFilial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoLogradouro:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoNumero:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoComplemento:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoCEP:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoBairro:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoCidade:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoEstado:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.SituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.DataSituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.MotivoSituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha MOTIVO DE SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha MOTIVO DE SITUAÇÃO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }

                case Coluna.ContatoEmail:
                    {
                        S = StringEntreString(S, "<!-- Início de Linha de Contato -->", "<!-- Fim de Linha de Contato -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }

                case Coluna.ContatoTel:
                    {
                        S = StringEntreString(S, "<!-- Início de Linha de Contato -->", "<!-- Fim de Linha de Contato -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</td>");
                        S = StringSaltaString(S, "</font>");
                        //S = StringEntreString(S, "<b>", "</font>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }

                case Coluna.EnteFederativo:
                    {
                        S = StringEntreString(S, "<!-- Início de Linha de Ente Federativo -->", "<!-- Fim de Linha de Ente Federativo -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }


                case Coluna.SituacaoEspecial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO ESPECIAL -->", "<!-- Fim Linha SITUACAO ESPECIAL-->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.DataSituacaoEspecial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO ESPECIAL -->", "<!-- Fim Linha SITUACAO ESPECIAL-->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }



                default:
                    {
                        return S;
                    }
            }
        }

        private String StringEntreString(String Str, String StrInicio, String StrFinal)
        {
            int Ini;
            int Fim;
            int Diff;
            Ini = Str.IndexOf(StrInicio);
            Fim = Str.IndexOf(StrFinal);
            if (Ini > 0) Ini = Ini + StrInicio.Length;
            if (Fim > 0) Fim = Fim + StrFinal.Length;
            Diff = ((Fim - Ini) - StrFinal.Length);
            if ((Fim > Ini) && (Diff > 0))
                return Str.Substring(Ini, Diff);
            else
                return "";
        }

        private String StringSaltaString(String Str, String StrInicio)
        {
            int Ini;
            Ini = Str.IndexOf(StrInicio);
            if (Ini > 0)
            {
                Ini = Ini + StrInicio.Length;
                return Str.Substring(Ini);
            }
            else
                return Str;
        }

        public string StringPrimeiraLetraMaiuscula(String Str)
        {
            string StrResult = "";
            if (Str.Length > 0)
            {
                StrResult += Str.Substring(0, 1).ToUpper();
                StrResult += Str.Substring(1, Str.Length - 1).ToLower();
            }
            return StrResult;
        }

        public class Empresa
        {
            public string Cnpj { get; set; }
            public string Razaosocial { get; set; }
            public string NomeFantasia { get; set; }
            public string endereco { get; set; }
            public string Bairro { get; set; }
            public string Cep { get; set; }
            public string Cnae { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string CnaeSecundaria { get; set; }
            public string NaturezaJuridica { get; set; }
            public string EnteFederativo { get; set; }
            public string SituacaoCadastral { get; set; }
            public string DataSituacaoCadastral { get; set; }
            public string MotivoSituacaoCadastral { get; set; }
            public string SituacaoEspecial { get; set; }
            public string DataSituacaoEspecial { get; set; }
            public string Complemento { get; set; }

        }

        private void FormConsultaSintegra_Load(object sender, EventArgs e)
        {
            picLetras.Image = null;

            this.BeginInvoke((MethodInvoker)delegate
            {
                backgroundWorker1.RunWorkerAsync();
            });
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                consulta = new ConsultaCNPJReceita();
                Bitmap bit = consulta.GetCaptcha();

                if (bit != null)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        ttbLetras.Focus();
                        picLetras.Image = bit;
                    });
                }
                else
                {
                    MessageBox.Show(this, "Não foi possível recuperar a imagem de validação do site da Receita Federal.", "CONSULTA CNPJ RFB");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Erro: " + ex.Message, Text);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAtualizar.Enabled = true;
            btnEnviar.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picLetras.Image = null;

            btnAtualizar.Enabled = false;
            btnEnviar.Enabled = false;

            this.BeginInvoke((MethodInvoker)delegate
            {
                backgroundWorker1.RunWorkerAsync();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor cursor;
            cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                maskedTxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação                
                string tmp = consulta.Consulta(maskedTxtCNPJ.Text, ttbLetras.Text);
                maskedTxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação

                if (tmp.Length > 0)
                {
                    empresa = new Empresa();

                    maskedTxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                    empresa.Cnpj = maskedTxtCNPJ.Text; //texto não formatado
                    maskedTxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals; // retorna a formatação

                    empresa.Razaosocial = RecuperaColunaValor(tmp, Coluna.RazaoSocial);
                    empresa.NomeFantasia = RecuperaColunaValor(tmp, Coluna.NomeFantasia);
                    empresa.endereco = RecuperaColunaValor(tmp, Coluna.EnderecoLogradouro);
                    empresa.endereco += ", " + RecuperaColunaValor(tmp, Coluna.EnderecoNumero);
                    empresa.Bairro = RecuperaColunaValor(tmp, Coluna.EnderecoBairro);
                    empresa.Cep = RecuperaColunaValor(tmp, Coluna.EnderecoCEP);

                    empresa.Cnae = RecuperaColunaValor(tmp, Coluna.AtividadeEconomicaPrimaria);
                    empresa.CnaeSecundaria = RecuperaColunaValor(tmp, Coluna.AtividadeEconomicaSecundaria);

                    empresa.Cidade = RecuperaColunaValor(tmp, Coluna.EnderecoCidade);
                    empresa.Estado = RecuperaColunaValor(tmp, Coluna.EnderecoEstado);

                    empresa.Email = RecuperaColunaValor(tmp, Coluna.ContatoEmail);
                    empresa.Telefone = RecuperaColunaValor(tmp, Coluna.ContatoTel);

                    empresa.NaturezaJuridica = RecuperaColunaValor(tmp, Coluna.NaturezaJuridica);

                    empresa.EnteFederativo = RecuperaColunaValor(tmp, Coluna.EnteFederativo);

                    empresa.SituacaoCadastral = RecuperaColunaValor(tmp, Coluna.SituacaoCadastral);
                    empresa.DataSituacaoCadastral = RecuperaColunaValor(tmp, Coluna.DataSituacaoCadastral);

                    empresa.MotivoSituacaoCadastral = RecuperaColunaValor(tmp, Coluna.MotivoSituacaoCadastral);

                    empresa.Complemento = RecuperaColunaValor(tmp, Coluna.EnderecoComplemento);

                    empresa.SituacaoEspecial = RecuperaColunaValor(tmp, Coluna.SituacaoEspecial);
                    empresa.DataSituacaoEspecial = RecuperaColunaValor(tmp, Coluna.DataSituacaoEspecial);

                    //Atribuição ao TextBox
                    //lblCNPJ.Text = empresa.Cnpj;
                    txtRazao.Text = empresa.Razaosocial;
                    txtFantasia.Text = empresa.NomeFantasia;
                    txtEndereco.Text = empresa.endereco;
                    txtBairro.Text = empresa.Bairro;
                    txtCep.Text = empresa.Cep;
                    txtCnae.Text = empresa.Cnae;
                    txtCidade.Text = empresa.Cidade;
                    txtUF.Text = empresa.Estado;
                    txtEmail.Text = empresa.Email;
                    txtTelefone.Text = empresa.Telefone;
                    txtSecundarias.Text = empresa.CnaeSecundaria;
                    txtBoxNaturezaJuridica.Text = empresa.NaturezaJuridica;
                    txtBoxEnteFederativo.Text = empresa.EnteFederativo;
                    txtSituacaoCadastral.Text = empresa.SituacaoCadastral;
                    txtDataSituacaoCadastral.Text = empresa.DataSituacaoCadastral;
                    txtMotivoSituacaoCadastral.Text = empresa.MotivoSituacaoCadastral;
                    txtSituacaoEspecial.Text = empresa.SituacaoEspecial;
                    txtDataSituacaoEspecial.Text = empresa.DataSituacaoEspecial;
                    txtComplemento.Text = empresa.Complemento;

                    string[] lines = { empresa.Razaosocial,
                                       empresa.NomeFantasia,
                                       empresa.Cnae,
                                       empresa.CnaeSecundaria,
                                       empresa.NaturezaJuridica,
                                       RecuperaColunaValor(tmp, Coluna.EnderecoLogradouro),
                                       RecuperaColunaValor(tmp, Coluna.EnderecoNumero),
                                       empresa.Complemento,
                                       empresa.Cep,
                                       empresa.Bairro,
                                       empresa.Cidade,
                                       empresa.Estado,
                                       empresa.Email,
                                       empresa.Telefone,
                                       empresa.EnteFederativo,
                                       empresa.SituacaoCadastral,
                                       empresa.DataSituacaoCadastral,
                                       empresa.MotivoSituacaoCadastral,
                                       empresa.SituacaoEspecial,
                                       empresa.DataSituacaoEspecial };

                    //String cnpjNomeArquivo = empresa.Cnpj;
                    //cnpjNomeArquivo = cnpjNomeArquivo.Replace("[^0-9]", "");

                    System.IO.File.WriteAllLines(empresa.Cnpj + ".txt", lines);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text);
                carregarCaptcha();
            }

            this.Cursor = cursor;
        }

        private void ttbLetras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnAtualizar.Enabled)
                {
                    button1_Click(sender, e);
                }
            }
        }
    }
}

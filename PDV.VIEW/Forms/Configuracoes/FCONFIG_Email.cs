using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_Email : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONFIGURAÇÃO DE EMAIL";
        private DataTable CONFIGURACOES = FuncoesConfiguracao.GetConfiguracoesEmail();

        public FCONFIG_Email()
        {
            InitializeComponent();
            CarregarConfiguracoes();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CarregarConfiguracoes()
        {
            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_SMTP'";
            ovTXT_SMTP.Text = CONFIGURACOES.DefaultView.Count == 1 ? Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[]) : string.Empty;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_PORTA'";
            ovTXT_Porta.Text = CONFIGURACOES.DefaultView.Count == 1 ? Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[]) : string.Empty;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_SSL'";
            ovCKB_SSL.Checked = CONFIGURACOES.DefaultView.Count == 1 ? Convert.ToDecimal(Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[])) == 1 : false;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_TSL'";
            ovCKB_TSL.Checked = CONFIGURACOES.DefaultView.Count == 1 ? Convert.ToDecimal(Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[])) == 1 : false;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_EMAIL'";
            ovTXT_Email.Text = CONFIGURACOES.DefaultView.Count == 1 ? Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[]) : string.Empty;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_SENHA'";
            ovTXT_Senha.Text = CONFIGURACOES.DefaultView.Count == 1 ? Criptografia.DecodificaSenha(Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[])) : string.Empty;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_REMETENTE'";
            ovTXT_EmailRemetente.Text = CONFIGURACOES.DefaultView.Count == 1 ? Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[]) : string.Empty;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_NOME_REMETENTE'";
            ovTXT_NomeRemetente.Text = CONFIGURACOES.DefaultView.Count == 1 ? Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[]) : string.Empty;

            CONFIGURACOES.DefaultView.RowFilter = "[CHAVE] = 'CONFIG_EMAIL_TIMEOUT'";
            ovTXT_TimeOut.Text = CONFIGURACOES.DefaultView.Count == 1 ? Encoding.UTF8.GetString(CONFIGURACOES.DefaultView[0]["VALOR"] as byte[]) : "100000";
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_SMTP, Encoding.Default.GetBytes(ovTXT_SMTP.Text)))
                    throw new Exception("Não foi possível salvar o SMTP.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_SMTP_PORT, Encoding.Default.GetBytes(ovTXT_Porta.Text)))
                    throw new Exception("Não foi possível salvar a Porta.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_SSL, Encoding.Default.GetBytes(ovCKB_SSL.Checked ? "1" : "0")))
                    throw new Exception("Não foi possível salvar o SSL");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_TLS, Encoding.Default.GetBytes(ovCKB_TSL.Checked ? "1" : "0")))
                    throw new Exception("Não foi possível salvar o TSL.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_USUARIO, Encoding.Default.GetBytes(ovTXT_Email.Text)))
                    throw new Exception("Não foi possível salvar o Usuário.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_SENHA, Encoding.Default.GetBytes(Criptografia.CodificaSenha(ovTXT_Senha.Text))))
                    throw new Exception("Não foi possível salvar a Senha.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_REMETENTE, Encoding.Default.GetBytes(ovTXT_EmailRemetente.Text)))
                    throw new Exception("Não foi possível salvar o E-mail do Remetente.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_NOME_REMETENTE, Encoding.Default.GetBytes(ovTXT_NomeRemetente.Text)))
                    throw new Exception("Não foi possível salvar o Nome do Remetente.");

                if (!FuncoesConfiguracao.Salvar(Email.EMAIL_TIMEOUT, Encoding.Default.GetBytes(ovTXT_TimeOut.Text)))
                    throw new Exception("Não foi possível salvar o TimeOut");

                PDVControlador.Commit();
               MessageBox.Show(this, "Configurações salvas com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ovTXT_EmailTeste.Text.Trim()))
            {
                MessageBox.Show(this, "Preencha o E-mail de Teste.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensagem = string.Format(@"﻿Você ou alguém acabou de realizar um teste das configurações de e-mail de {3} e informou o endereço de e-mail {0} como destinatário.<br/>
            Caso não tenha sido você, por gentileza, desconsidere esta mensagem.<br/>
            Teste realizado às {1} do dia {2}.<br/>", ovTXT_EmailTeste.Text, DateTime.Now.ToString("HH:mm:ss"), DateTime.Now.ToString("dd/MM/yyyy"), string.Format("DUE SISTEMAS  {0}", Contexto.VERSAO));

            Email _Email = new Email();

            _Email.Assunto = "Teste de configuração de e-mail";
            _Email.Mensagem = mensagem;
            _Email.Titulo = "Email Teste";

            _Email.EmailDestinatario = new List<string>();
            _Email.EmailDestinatario.Add(ovTXT_EmailTeste.Text);

            _Email.EmailRemetente = ovTXT_EmailRemetente.Text;
            _Email.NomeRemetente = ovTXT_NomeRemetente.Text;
            _Email.TimeOut = ovTXT_TimeOut.Text;

            _Email.ServidorEmail = ovTXT_SMTP.Text;
            _Email.Porta = ovTXT_Porta.Text;
            _Email.UsarSSL = ovCKB_SSL.Checked ? "1" : "0";
            _Email.UsarTLS = ovCKB_TSL.Checked ? "1" : "0";
            _Email.Usuario = ovTXT_Email.Text;
            _Email.Senha = ovTXT_Senha.Text;

            string MensagemRetorno = ZeusUtil.EnviarEmail(_Email, Contexto.USUARIOLOGADO.Nome);

            if (MensagemRetorno.Equals("OK"))
               MessageBox.Show(this, "E-mail enviado com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
               MessageBox.Show(this, MensagemRetorno, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

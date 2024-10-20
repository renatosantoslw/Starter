using Cappta.Gp.Api.Com.Model;
using PDV.VIEW.FRENTECAIXA;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Cappta.Gp.Api.Com.Sample.Model
{
	public class CreateClienteCappta : ClienteCappta
	{
		private bool clientConectado;

		public void AutenticarPdv()
		{
			var chaveAutenticacao = ConfigurationManager.AppSettings["ChaveAutenticacao"];
			if (String.IsNullOrWhiteSpace(chaveAutenticacao)) { this.InvalidarAutenticacao("Chave de Autenticação inválida"); }

			var cnpj = ConfigurationManager.AppSettings["Cnpj"];
			if (String.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14) { this.InvalidarAutenticacao("CNPJ inválido"); }

			int pdv;
			if (Int32.TryParse(ConfigurationManager.AppSettings["Pdv"], out pdv) == false || pdv == 0)
			{
				this.InvalidarAutenticacao("PDV inválido");
			}

			int resultadoAutenticacao = this.AutenticarPdv(cnpj, pdv, chaveAutenticacao);
			if (resultadoAutenticacao == 0) { clientConectado = true; return ; }

			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));			

			this.ExibeMensagemAutenticacaoInvalida(resultadoAutenticacao);

			return;
		}

		public void InvalidarAutenticacao(string mensagemErro)
		{
			var notificable = new Notificable();
			notificable.CriarMensagemErroJanela(String.Format("{0}. Verifique seu valor no arquivo de configuração.", mensagemErro));
		}

		public void ExibeMensagemAutenticacaoInvalida(int resultadoAutenticacao)
		{
			var mensagem = Mensagens.ResourceManager.GetString(string.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
			MessageBox.Show(mensagem, "SAMPLE API COM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		
		}

		public int ConfigurarModoIntegracao(bool exibirInterface)
		{	
			if(clientConectado == false) { return 1; }
			IConfiguracoes configs = new Configuracoes { ExibirInterface = exibirInterface };
			int resultado = this.Configurar(configs);

			return resultado;
		}

	}
}

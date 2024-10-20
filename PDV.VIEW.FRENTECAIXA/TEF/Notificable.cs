using Cappta.Gp.Api.Com.Model;
using PDV.VIEW.FRENTECAIXA;
using System;
using System.Windows.Forms;

namespace Cappta.Gp.Api.Com.Sample.Model
{
	public class Notificable
	{
		public void CriarMensagemErroJanela(string mensagem)
		{
			MessageBox.Show(mensagem, "Erro");
		}

		public string ExibirMensagem(IMensagem mensagem)
		{
			return mensagem.Descricao;
		}

		public string GerarMensagemTransacaoAprovada()
		{
			string mensagem = String.Format("Transaç Aprovada!!!  Clique em \"OK\" para confirmar a transaç e \"Cancelar\" para desfaze-la.",
				Environment.NewLine);

			return mensagem;
		}

		public string CriarMensagemErroPainel(int resultado)
		{
			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultado));
			if (String.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

			return String.Format("{0}. Código de erro {1}", mensagem, resultado);
		}
	}
}

using System;
using System.Runtime.InteropServices;

namespace IntegracaoMFE.DLLs
{
    internal static class DLLMfe
    {

        /// <summary>
        /// Consultar MFE
        /// </summary>
        /// <param name="numeroSessao">Número da Sessão</param>
        [DllImport(@"mfe.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ConsultarSAT(int numeroSessao);

        /// <summary>
        /// Enviar Dados Venda
        /// </summary>
        /// <param name="numeroSessao">Número da Sessão</param>
        /// <param name="codigoDeAtivacao">Código de Ativação</param>
        /// <param name="dadosVenda">XML da Venda</param>
        [DllImport(@"mfe.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        /// <summary>
        /// Cancelar a última Venda
        /// </summary>
        /// <param name="numeroSessao">Número da Sessão</param>
        /// <param name="codigoDeAtivacao">Código de Ativação</param>
        /// <param name="chaveCFe">Chave de Acesso da CF-e a ser cancelado</param>
        /// <param name="dadosCancelamento">XML com os dados de cancelamento</param>
        [DllImport(@"mfe.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chaveCFe, string dadosCancelamento);


        /// <summary>
        /// Consultar Número de Sessão MFE
        /// </summary>
        /// <param name="numeroSessao">Número da Sessão</param>
        /// <param name="codigoDeAtivacao">Código de Ativação</param>
        /// <param name="numeroSessaoConsultada">Número da sessão a ser consultada</param>
        [DllImport(@"mfe.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int numeroSessaoConsultada);


        /// <summary>
        /// Consultar Status Operacional da MFE
        /// </summary>
        /// <param name="numeroSessao">Número da Sessão</param>
        /// <param name="codigoDeAtivacao">Código de Ativação</param>
        [DllImport(@"mfe.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao);
    }
}

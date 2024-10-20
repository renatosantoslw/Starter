using ACBr.Net.Sat;
using IntegracaoMFE.DLLs;
using IntegracaoMFE.Utils;
using IntegracaoMFE.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;

namespace IntegracaoMFE
{
    public class MFE
    {
        #region Variáveis

        /// <summary>
        /// Pasta Input do Integrador Fiscal
        /// <para> Obrigatório Informar quando for os métodos VFP-E ou quando for Autorização e Cancelamento se o TipoEnvioDLL for False</para>
        /// </summary>
        public string PastaImput { get; set; }

        /// <summary>
        /// Pasta OutPut do Integrador Fiscal
        /// <para> Obrigatório Informar quando for os métodos VFP-E ou quando for Autorização e Cancelamento se o TipoEnvioDLL for False</para>
        /// </summary>
        public string PastaOutput { get; set; }

        /// <summary>
        /// Tipo de Envio de Comunicação por DLL com Integrador
        /// <para>True: Envio por DLL</para>
        /// <para>False: Envio por Comunicação com Pastas do Integrador Fiscal</para>
        /// </summary>
        public bool TipoEnvioDLL { get; set; } = false;

        /// <summary>
        /// Código de Ativação do Equipamento
        /// </summary>
        public string CodigoAtivacao { get; set; }

        /// <summary>
        /// Realizar a Gravação dos XMLs da Venda e Cancelamento em uma Pasta
        /// <para>True: Irá gravar na pasta informada em LocalArquivoXML</para>
        /// <para>False: Não irá gravar o XML</para>
        /// </summary>
        public bool GravarXmlEmPasta { get; set; } = false;

        /// <summary>
        /// Caminho da Pasta onde salvar os XMLs das Vendas e Cancelamento
        /// <para>Obrigatório informar o local se GravarXmlEmPasta estiver True</para>
        /// </summary>
        public string LocalArquivoXML { get; set; }

        /// <summary>
        /// Campo que recebe o XML de Retorno da Autorização (XML da Venda)
        /// </summary>
        public ACBr.Net.Sat.CFe XmlRetornoAutorizacaoMFE { get; set; }

        /// <summary>
        /// Campo que recebe o Retorno do Cancelamento (XML do Cancelamento)
        /// </summary>
        public ACBr.Net.Sat.CFeCanc XmlRetornoCancelamentoMFE { get; set; }

        /// <summary>
        /// Dados com os Retornos dos envios do VFP-E
        /// </summary>
        public RetornosVFPE RetornoVFPE { get; set; }
        #endregion

        #region Métodos

        //MFE

        /// <summary>
        /// Realiza Verificação de Comunicação com o MFE<para/>
        /// Retorno: Classe RetornosMFE
        /// </summary>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE VerificarComunicacao()
        {
            try
            {
                Random ram = new Random();
                if (TipoEnvioDLL)
                {

                    IntPtr ptr = DLLMfe.ConsultarSAT(ram.Next(1, 999999)); 
                    int length = 0;
                    while (Marshal.ReadByte(ptr + length) != 0)
                        length++;
                    byte[] strbuf = new byte[length];
                    Marshal.Copy(ptr, strbuf, 0, length);
                    string resposta = Encoding.UTF8.GetString(strbuf);
                    string[] texto = resposta.Split('|');
                    RetornosMFE retorno;
                    if (texto.Length >= 3)
                        retorno = new RetornosMFE(Convert.ToInt32(texto[1]), texto[2], resposta);
                    else
                        if (texto.Length > 1)
                        retorno = new RetornosMFE(Convert.ToInt32(texto[1]), resposta);
                    else
                        retorno = new RetornosMFE(0, string.IsNullOrEmpty(resposta) ? "MFE não retornou o status de comunicação" : resposta);
                    return retorno;
                }
                else
                {
                    int identificador = ram.Next(999999, 999999999);
                    string numeroSessao = ram.Next(1, 999999).ToString();
                    DateTime dataHora = DateTime.Now;

                    //Montando o XML de Consulta MFE
                    string xmlConsultaMFE = IntegradorXml.ConsultarMfeXml(numeroSessao, identificador.ToString());

                    //Verificando a existência de pasta para gravar o Arquivo e removendo arquivos antigos
                    VerificacaoPastasIntegrador("ConsultarMFE");

                    //Gravando Arquivo na Pasta Input
                    using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\ConsultarMFE_" + numeroSessao + ".TMP"))
                    {
                        stream.WriteLine(xmlConsultaMFE);
                        stream.Close();
                    }
                    //Jogando o Arquivo da pasta Ler para a Oficial
                    while (!File.Exists(PastaImput + "\\Ler\\ConsultarMFE_" + numeroSessao + ".TMP"))
                    { }
                    File.Copy(PastaImput + "\\Ler\\ConsultarMFE_" + numeroSessao + ".TMP", PastaImput + "\\" + Criptografia.MD5("ConsultarMFE_" + numeroSessao + dataHora.TimeOfDay.ToString()) + ".xml");

                    //Realizando a Leitura da Pasta OutPut
                    XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                    //Tratando o Retorno
                    return TratandoRetornoIntegrador(xmlRetorno);
                }
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        /// <summary>
        /// Realiza o Envio da Autorização da Venda MFE<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades XmlRetornoAutorizacaoMFE
        /// </summary>
        /// <param name="XmlAutorizacaoMFE">XML da Venda</param>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE AutorizacaoMFE(string XmlAutorizacaoMFE)
        {
            int numeroSessao = new Random().Next(1, 999999);
            string[] textoRetorno = null;
            try
            {
                //Verificando Comunicação com MFE
                RetornosMFE retornosMFE = VerificarComunicacao();

                //Retornando a Venda como Erro de Comunicacao
                if (retornosMFE.MfeEmOperacao() == false)
                    return retornosMFE;

                //Transmitindo
                if (TipoEnvioDLL)
                {
                    //Iniciando Autorização MFE   

                    int numerofinal = new Random().Next(numeroSessao, 999999);


                    IntPtr ptr = DLLMfe.EnviarDadosVenda(Convert.ToInt32(numerofinal) , CodigoAtivacao, XmlAutorizacaoMFE); 
                    int length = 0;
                    while (Marshal.ReadByte(ptr + length) != 0)
                        length++;
                    byte[] strbuf = new byte[length];
                    Marshal.Copy(ptr, strbuf, 0, length);
                    string resposta = Encoding.UTF8.GetString(strbuf);

                    //Tratando Retorno da Autorização MFE
                    textoRetorno = resposta.Split('|');
                    if (textoRetorno.Length >= 3)
                        retornosMFE = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), textoRetorno[3], numeroSessao, resposta);
                    else if (textoRetorno.Length > 1)
                        retornosMFE = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), resposta);
                    else
                        retornosMFE = new RetornosMFE(0, resposta);

                    //Erro na Aprovação
                    if (retornosMFE.Autorizada() == false)
                        return retornosMFE;
                }
                else
                {
                    int identificador = new Random().Next(999999, 999999999);
                    DateTime dataHora = DateTime.Now;

                    // Montagem do XML do Integrador
                    string xmlEnviarDadosMFE = IntegradorXml.EnviarDadosVendaXml(numeroSessao.ToString(), identificador.ToString(), CodigoAtivacao, XmlAutorizacaoMFE);

                    //Verificando a existência de pasta para gravar o Arquivo e removendo arquivos antigos
                    VerificacaoPastasIntegrador("EnviarDadosVenda");

                    //Gravando Arquivo na Pasta Input
                    using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\EnviarDadosVenda_" + numeroSessao + ".TMP"))
                    {
                        stream.WriteLine(xmlEnviarDadosMFE);
                        stream.Close();
                    }
                    while (!File.Exists(PastaImput + "\\Ler\\EnviarDadosVenda_" + numeroSessao + ".TMP"))
                    { }
                    File.Copy(PastaImput + "\\Ler\\EnviarDadosVenda_" + numeroSessao + ".TMP", PastaImput + "\\" + Criptografia.MD5("EnviarDadosVenda_" + numeroSessao + dataHora.TimeOfDay.ToString()) + ".xml");

                    //Realizando a Leitura da Pasta OutPut
                    XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                    //Tratando o Retorno
                    retornosMFE = TratandoRetornoIntegrador(xmlRetorno);

                    //Erro na Aprovação
                    if (retornosMFE.Autorizada() == false)
                        return retornosMFE;

                    textoRetorno = retornosMFE.MensagemRetornoCompleto.Split('|');
                }

                //Convertendo XML de Base64 para Texto
                Byte[] b = Convert.FromBase64String(textoRetorno[6]);
                string xmlConvertido = UTF8Encoding.UTF8.GetString(b);

                if (GravarXmlEmPasta)
                {
                    try
                    {
                        Arquivos.GravarArquivo(LocalArquivoXML, xmlConvertido, textoRetorno[8] + ".xml");
                    }
                    catch (Exception)
                    {
                        //Erro na gravação do XML na pasta, mas será continuado a aprovação da Venda
                    }
                }

                //Gravando na Propriedade o XML da Venda
                XmlRetornoAutorizacaoMFE = CFe.Load(xmlConvertido);

                return retornosMFE;
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message, numeroSessao);
            }
        }

        /// <summary>
        /// Realiza o Cancelamento da Venda MFE<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades XmlRetornoCancelamentoMFE
        /// </summary>
        /// <param name="chaveAcessoCfe">Chave de Acesso da Venda MFE<para>Informe com "CFe" na frente do número. Exemplo: CFe35191008723218000186599000133060008767680821</para></param>
        /// <param name="XmlCancelamentoMFE">XML do Cancelamento MFE</param>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE CancelamentoMFE(string ChaveAcessoCfe, string XmlCancelamentoMFE)
        {
            int numeroSessao = new Random().Next(1, 999999);
            string[] textoRetorno = null;
            try
            {
                //Verificar se o MFE está comunicando 
                RetornosMFE retornosMFE = VerificarComunicacao();

                //Retornando o Cancelamento com Erro de Comunicação
                if (retornosMFE.MfeEmOperacao() == false)
                    return retornosMFE;

                //Transmitindo
                if (TipoEnvioDLL)
                {
                    //Enviando o XML CFe de Cancelamento
                    IntPtr ptr = DLLMfe.CancelarUltimaVenda(numeroSessao, CodigoAtivacao, ChaveAcessoCfe, XmlCancelamentoMFE);
                    int length = 0;
                    while (Marshal.ReadByte(ptr + length) != 0)
                        length++;
                    byte[] strbuf = new byte[length];
                    Marshal.Copy(ptr, strbuf, 0, length);
                    string resposta = Encoding.UTF8.GetString(strbuf);

                    //Retorno do Cancelamento
                    textoRetorno = resposta.Split('|');
                    if (textoRetorno.Length >= 3)
                        retornosMFE = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), textoRetorno[3], resposta);
                    else if (textoRetorno.Length > 1)
                        retornosMFE = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), resposta);
                    else
                        retornosMFE = new RetornosMFE(0, resposta);

                    //Erro na Aprovação do Cancelamento
                    if (retornosMFE.Cancelada() == false)
                        return retornosMFE;
                }
                else
                {
                    int identificador = new Random().Next(999999, 999999999);
                    DateTime dataHora = DateTime.Now;

                    //Enviando o XML CFe de Cancelamento
                    string xmlCfeCancelamento = IntegradorXml.CancelarUltimaVendaXml(numeroSessao.ToString(), identificador.ToString(), CodigoAtivacao, ChaveAcessoCfe, XmlCancelamentoMFE);

                    //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                    VerificacaoPastasIntegrador("CancelarUltimaVenda");

                    //Gravando Arquivo na Pasta Input
                    using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\CancelarUltimaVenda_" + numeroSessao + ".TMP"))
                    {
                        stream.WriteLine(xmlCfeCancelamento);
                        stream.Close();
                    }
                    while (!File.Exists(PastaImput + "\\Ler\\CancelarUltimaVenda_" + numeroSessao + ".TMP"))
                    { }
                    File.Copy(PastaImput + "\\Ler\\CancelarUltimaVenda_" + numeroSessao + ".TMP", PastaImput + "\\" + Criptografia.MD5("CancelarUltimaVenda_" + numeroSessao + dataHora.TimeOfDay.ToString()) + ".xml");

                    //Realizando a Leitura da Pasta OutPut
                    XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                    //Tratando os Dados de Retorno
                    retornosMFE = TratandoRetornoIntegrador(xmlRetorno);

                    //Erro na Aprovação do Cancelamento
                    if (retornosMFE.Cancelada())
                        return retornosMFE;

                    textoRetorno = retornosMFE.MensagemRetornoCompleto.Split('|');
                }

                //Convertendo XML de Base64 para Texto
                Byte[] b = Convert.FromBase64String(textoRetorno[6]);
                string xmlConvertido = UTF8Encoding.UTF8.GetString(b);

                if (GravarXmlEmPasta)
                {
                    try
                    {
                        Arquivos.GravarArquivo(LocalArquivoXML, xmlConvertido, textoRetorno[8] + ".xml");
                    }
                    catch (Exception)
                    {
                        //Erro na gravação do XML na pasta, mas será continuado a aprovação do Cancelamento da Venda
                    }
                }

                //Gravando na Propriedade o XML do Cancelamento
                XmlRetornoCancelamentoMFE = CFeCanc.Load(xmlConvertido);

                return retornosMFE;
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message, numeroSessao);
            }
        }

        /// <summary>
        /// Realiza a Consulta da Sessão MFE<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades XmlRetornoCancelamentoMFE e XmlRetornoAutorizacaoMFE dependendo o retornoMFE
        /// </summary>
        /// <param name="numeroSessao">Número da Sessão a ser Consultada</param>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE ConsultaSessaoMFE(int numeroSessaoConsultar)
        {
            int numeroSessao = new Random().Next(1, 999999);
            string[] textoRetorno = null;
            try
            {
                //Verificar se o MFE está comunicando 
                RetornosMFE retornosMFE = VerificarComunicacao();

                //Retornando o Consulta Sessão com Erro de Comunicação
                if (retornosMFE.MfeEmOperacao())
                    return retornosMFE;

                //Transmitindo
                if (TipoEnvioDLL)
                {
                    IntPtr ptr = DLLMfe.ConsultarNumeroSessao(numeroSessao, CodigoAtivacao, numeroSessaoConsultar);
                    int length = 0;
                    while (Marshal.ReadByte(ptr + length) != 0)
                        length++;
                    byte[] strbuf = new byte[length];
                    Marshal.Copy(ptr, strbuf, 0, length);
                    string resposta = Encoding.UTF8.GetString(strbuf);

                    textoRetorno = resposta.Split('|');
                    if (textoRetorno.Length >= 3)
                        retornosMFE = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), textoRetorno[3], resposta);
                    else if (textoRetorno.Length > 1)
                        retornosMFE = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), resposta);
                    else
                        retornosMFE = new RetornosMFE(0, resposta);

                    //Retornando Sessão como não Autorizada ou Cancelada
                    if (retornosMFE.Autorizada() == false && retornosMFE.Cancelada() == false)
                        return retornosMFE;
                }
                else
                {
                    int identificador = new Random().Next(999999, 999999999);
                    DateTime dataHora = DateTime.Now;

                    // Montagem do XML do Integrador
                    string xmlConsultaNumeroSessao = IntegradorXml.ConsultaNumeroSessao(identificador.ToString(), numeroSessaoConsultar.ToString());

                    //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                    VerificacaoPastasIntegrador("ConsultaNumeroSessao");

                    //Gravando Arquivo na Pasta Input
                    using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\ConsultaNumeroSessao" + numeroSessao + ".TMP"))
                    {
                        stream.WriteLine(xmlConsultaNumeroSessao);
                        stream.Close();
                    }
                    while (!File.Exists(PastaImput + "\\Ler\\ConsultaNumeroSessao_" + numeroSessao + ".TMP"))
                    { }
                    File.Copy(PastaImput + "\\Ler\\ConsultaNumeroSessao_" + numeroSessao + ".TMP", PastaImput + "\\" + Criptografia.MD5("ConsultaNumeroSessao_" + numeroSessao + dataHora.TimeOfDay.ToString()) + ".xml");

                    //Realizando a Leitura da Pasta OutPut
                    XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                    //Tratando os Dados de Retorno
                    retornosMFE = TratandoRetornoIntegrador(xmlRetorno);

                    //Retornando Sessão como não Autorizada ou Cancelada
                    if (retornosMFE.Autorizada() == false && retornosMFE.Cancelada() == false)
                        return retornosMFE;

                    textoRetorno = retornosMFE.MensagemRetornoCompleto.Split('|');
                }

                //Convertendo XML de Base64 para Texto
                Byte[] b = Convert.FromBase64String(textoRetorno[6]);
                string xmlConvertido = UTF8Encoding.UTF8.GetString(b);

                if (GravarXmlEmPasta)
                {
                    try
                    {
                        Arquivos.GravarArquivo(LocalArquivoXML, xmlConvertido, textoRetorno[8] + ".xml");
                    }
                    catch (Exception)
                    {
                        //Erro na gravação do XML na pasta, mas será continuado
                    }
                }

                //Gravando na Propriedade o XML da Venda
                if (retornosMFE.Autorizada())
                    XmlRetornoAutorizacaoMFE = CFe.Load(xmlConvertido);

                //Gravando na Propriedade o XML do Cancelamento
                if (retornosMFE.Cancelada())
                    XmlRetornoCancelamentoMFE = CFeCanc.Load(xmlConvertido);

                return retornosMFE;

            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        /// <summary>
        /// Realiza a Consulta do Status Operacional do MFE<para/>
        /// Retorno: Classe RetornosMFE (No campo MensagemRetornoCompleto todos os dados de Status Operacional)
        /// </summary>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE ConsultaStatusOperacional()
        {
            int numeroSessao = new Random().Next(1, 999999);
            try
            {
                //Verificar se o MFE está comunicando 
                RetornosMFE retornosMFE = VerificarComunicacao();

                //Retornando o Consulta Status Operação com Erro de Comunicação
                if (retornosMFE.MfeEmOperacao())
                    return retornosMFE;

                //Transmitindo
                if (TipoEnvioDLL)
                {
                    //Verificação do Status Operacional
                    IntPtr ptr = DLLMfe.ConsultarStatusOperacional(numeroSessao, CodigoAtivacao);
                    int length = 0;
                    while (Marshal.ReadByte(ptr + length) != 0)
                        length++;
                    byte[] strbuf = new byte[length];
                    Marshal.Copy(ptr, strbuf, 0, length);
                    string resposta = Encoding.UTF8.GetString(strbuf);

                    string[] textoRetorno = resposta.Split('|');
                    RetornosMFE retorno;
                    if (textoRetorno.Length >= 3)
                        retorno = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), textoRetorno[2], resposta);
                    else if (textoRetorno.Length > 1)
                        retorno = new RetornosMFE(Convert.ToInt32(textoRetorno[1]), resposta);
                    else
                        retorno = new RetornosMFE(0, string.IsNullOrEmpty(resposta) ? "MFE não retornou o status de operacional" : resposta);
                    return retorno;
                }
                else
                {
                    int identificador = new Random().Next(999999, 999999999);
                    DateTime dataHora = DateTime.Now;

                    //Montado XML ConsultaStatusOperacional
                    string xmlConsultaMFE = IntegradorXml.ConsultarStatusOperacionalXml(numeroSessao.ToString(), identificador.ToString());

                    //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                    VerificacaoPastasIntegrador("ConsultaStatusOperacional");

                    //Gravando Arquivo na Pasta Input
                    using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\ConsultaStatusOperacional_" + numeroSessao + ".TMP"))
                    {
                        stream.WriteLine(xmlConsultaMFE);
                        stream.Close();
                    }
                    while (!File.Exists(PastaImput + "\\Ler\\ConsultaStatusOperacional_" + numeroSessao + ".TMP"))
                    { }
                    File.Copy(PastaImput + "\\Ler\\ConsultaStatusOperacional_" + numeroSessao + ".TMP", PastaImput + "\\" + Criptografia.MD5("ConsultaStatusOperacional_" + numeroSessao + dataHora.TimeOfDay.ToString()) + ".xml");

                    //Realizando a Leitura da Pasta OutPut
                    XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                    //Tratando os Dados de Retorno
                    return TratandoRetornoIntegrador(xmlRetorno);
                }
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        //VFP-E

        /// <summary>
        /// Realiza o Envio do Pagamento<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades a Classe RetornosVFPE
        /// </summary>
        /// <param name="baseICMS">Valor da Base de ICMS Total da Venda</param>
        /// <param name="chaveAcessoValidador">Chave de Acesso do Validador</param>
        /// <param name="cnpjAdquirente">CNPJ da Administradora do Cartão</param>
        /// <param name="cnpjLoja">CNPJ da Loja</param>
        /// <param name="estabelecimento">Código do Estabelecimento/MerchantID fornecido pela Adquirente</param>
        /// <param name="habilitarMultiplosPagamentos">Habilitar Multiplus Pagamento. True: Vários Pagamentos. False: Único Pagamento</param>
        /// <param name="origemPagamento">Informações de Controle (exemplo um ID para identificar a Venda posteriormente)</param>
        /// <param name="serialPos">Número  Serial  do  POS. Caso TEF utilize apenas a palavra TEF</param>
        /// <param name="valorTotalVenda">Valor Total da Venda</param>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE EnviarPagamento(string chaveAcessoValidador, string cnpjLoja, string cnpjAdquirente, string estabelecimento, decimal baseICMS,
                                           decimal valorTotalVenda, string origemPagamento, string serialPos = "TEF", bool habilitarMultiplosPagamentos = true)
        {
            try
            {
                //Montagem do XML do EnviarPagamento
                Random ram = new Random();
                int identificador = ram.Next(999999, 999999999);
                string xmlEnviarPagamento = IntegradorXml.EnviarPagamentoVFPe(identificador.ToString(), chaveAcessoValidador, GerarChaveRequisicao(cnpjLoja, string.IsNullOrEmpty(cnpjAdquirente) ? "00000000000000" : cnpjAdquirente),
                    string.IsNullOrEmpty(estabelecimento) ? "00000000" : estabelecimento, serialPos, Texto.SomenteNumeros(cnpjLoja), baseICMS, valorTotalVenda, origemPagamento, habilitarMultiplosPagamentos);

                //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                VerificacaoPastasIntegrador("EnviarPagamento");

                DateTime dataHora = DateTime.Now;

                //Gravando na Pasta Input
                using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\EnviarPagamento_" + identificador.ToString() + ".TMP"))
                {
                    stream.WriteLine(xmlEnviarPagamento);
                    stream.Close();
                }
                while (!File.Exists(PastaImput + "\\Ler\\EnviarPagamento_" + identificador.ToString() + ".TMP"))
                { }
                File.Copy(PastaImput + "\\Ler\\EnviarPagamento_" + identificador.ToString() + ".TMP", PastaImput + "\\" + Criptografia.MD5("EnviarPagamento_" + identificador.ToString() + dataHora.TimeOfDay.ToString()) + ".xml");

                //Realizando a Leitura da Pasta OutPut
                XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                //Tratando os Dados de Retorno
                RetornosMFE retornosMFE = TratandoRetornoVFPe(xmlRetorno);
                if (retornosMFE.VFeRealizada())
                {
                    string[] texto = retornosMFE.MensagemRetornoCompleto.Split('|');
                    if (texto.Length == 2)
                    {
                        RetornoVFPE = new RetornosVFPE(Convert.ToInt32(texto[0]), Convert.ToBoolean(texto[1]));
                    }
                    else //Erro no Envio do Pagamento
                        RetornoVFPE = new RetornosVFPE(0, true);
                }
                else //Erro no Envio do Pagamento
                    RetornoVFPE = new RetornosVFPE(0, true);

                return retornosMFE;
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        /// <summary>
        /// Envia os Dados do Pagamento<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades a Classe RetornosVFPE
        /// </summary>
        /// <param name="chaveAcessoValidador">Chave de Acesso do Validador</param>
        /// <param name="autorizacao">Número da Autorização do Cartão</param>
        /// <param name="binCartao">Sequencial de 6 Números  iniciais  do  cartão</param>
        /// <param name="nomeAdquirente">Nome da Adquirente</param>
        /// <param name="nomeBandeira">Nome da Bandeira</param>
        /// <param name="nsu">Número Sequencial Único do pagamento</param>
        /// <param name="qtdParcelas">Quantidade de Parcelas</param>
        /// <param name="ultimos4DigitosCartao">Últimos 4 dígitos do cartão se fornecido pela Adquirente</param>
        /// <param name="valorCartao">Valor do Pagamento</param>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE EnviarStatusPagamento(string chaveAcessoValidador, string autorizacao, string binCartao, string nomeAdquirente, int qtdParcelas,
                                                 string nsu, decimal valorCartao, string nomeBandeira, string ultimos4DigitosCartao)
        {
            try
            {
                //Montagem do XML
                Random ram = new Random();
                int identificador = ram.Next(999999, 999999999);
                string xmlEnviarStatusPagamento = IntegradorXml.EnviarStatusPagamentoVFPe(identificador.ToString(), chaveAcessoValidador, autorizacao, binCartao, nomeAdquirente,
                                                                                     qtdParcelas, nsu, valorCartao, RetornoVFPE.IdPagamento.ToString(), nomeBandeira, ultimos4DigitosCartao);

                //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                VerificacaoPastasIntegrador("EnviarStatusPagamento");

                DateTime dataHora = DateTime.Now;

                //Gravando na Pasta Input
                using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\EnviarStatusPagamento_" + identificador + ".TMP"))
                {
                    stream.WriteLine(xmlEnviarStatusPagamento);
                    stream.Close();
                }
                while (!File.Exists(PastaImput + "\\Ler\\EnviarStatusPagamento_" + identificador + ".TMP"))
                { }
                File.Copy(PastaImput + "\\Ler\\EnviarStatusPagamento_" + identificador + ".TMP", PastaImput + "\\" + Criptografia.MD5("EnviarStatusPagamento_" + identificador + dataHora.TimeOfDay.ToString()) + ".xml");

                //Realizando a Leitura da Pasta OutPut
                XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                //Tratando os Dados de Retorno
                RetornosMFE retornosMFE = TratandoRetornoVFPe(xmlRetorno);
                if (retornosMFE.VFeRealizada())
                {
                    if (retornosMFE.DescricaoRetorno == RetornoVFPE.IdPagamento.ToString())
                        RetornoVFPE.MfeEnviadoDadosCartao = true;
                    else //Erro no Envio Status do Pagamento
                        RetornoVFPE.MfeEnviadoDadosCartao = false;
                }
                else //Erro no Envio Status do Pagamento
                    RetornoVFPE.MfeEnviadoDadosCartao = false;

                return retornosMFE;
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        /// <summary>
        /// Realiza o Envio da Resposta Fiscal<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades a Classe RetornosVFPE
        /// </summary>
        /// <param name="chaveAcessoValidador">Chave de Acesso do Validador</param>
        /// <param name="autorizacao">Número da Autorização do Cartão</param>
        /// <param name="nsu">Número Sequencial Único do pagamento</param>
        /// <param name="nomeAdquirente">Nome da Adquirente</param>
        /// <param name="nomeBandeira">Nome da Bandeira</param>
        /// <param name="cnpjLoja">CNPJ da Loja</param>
        /// <param name="chaveAcesso">Chave de Acesso da Venda (Se modelo de nota 59 informar com a palavra CFe na frente. Exemplo: CFe35191008723218000186599000133060008767680821)</param>
        /// <param name="numeroNotaFiscal">Número da Nota Fiscal</param>
        /// <returns>Classe RetornosMFE</returns>
        public RetornosMFE RespostaFiscal(string chaveAcessoValidador, string chaveAcesso, string nsu, string autorizacao, string nomeBandeira, string nomeAdquirente,
                                          string cnpjLoja, string numeroNotaFiscal, string ImpressaoFiscal)
        {
            try
            {
                //Montagem do XML do RespostaFiscal
                Random ram = new Random();
                int identificador = ram.Next(999999, 999999999);
                string xmlRespostaFiscal = IntegradorXml.RespostaFiscalVFPe(identificador.ToString(), chaveAcessoValidador, RetornoVFPE.IdPagamento.ToString(), chaveAcesso, nsu, autorizacao,
                                                                                   nomeBandeira, nomeAdquirente, Texto.SomenteNumeros(cnpjLoja), numeroNotaFiscal, ImpressaoFiscal);

                //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                VerificacaoPastasIntegrador("RespostaFiscal");

                DateTime dataHora = DateTime.Now;

                //Gravando na Pasta Input
                using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\RespostaFiscal_" + identificador.ToString() + ".TMP"))
                {
                    stream.WriteLine(xmlRespostaFiscal);
                    stream.Close();
                }
                while (!File.Exists(PastaImput + "\\Ler\\RespostaFiscal_" + identificador.ToString() + ".TMP"))
                { }
                File.Copy(PastaImput + "\\Ler\\RespostaFiscal_" + identificador + ".TMP", PastaImput + "\\" + Criptografia.MD5("RespostaFiscal_" + identificador + dataHora.TimeOfDay.ToString()) + ".xml");

                //Realizando a Leitura da Pasta OutPut
                XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());

                //Tratando os Dados de Retorno
                RetornosMFE retornosMFE = TratandoRetornoVFPe(xmlRetorno);
                if (retornosMFE.VFeRealizada())
                {
                    long ret = 0;
                    if (long.TryParse(retornosMFE.MensagemRetornoCompleto, out ret))
                        RetornoVFPE.IdRespostaFiscal = ret;
                    else //Erro no Resposta Fiscal
                        RetornoVFPE.IdRespostaFiscal = 0;
                }
                else //Erro no Resposta Fiscal
                    RetornoVFPE.IdRespostaFiscal = 0;

                return retornosMFE;
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        /// <summary>
        /// Realiza a Verificação e Busca dos Dados do Cartão<para/>
        /// Retorno: Classe RetornosMFE e nas Propriedades a Classe RetornosVFPE
        /// </summary>
        /// <param name="chaveAcessoValidador">Chave de Acesso do Validador</param>
        /// <param name="cnpjLoja">CNPJ da Loja</param>
        /// <returns></returns>
        public RetornosMFE VerificarStatusValidador(string chaveAcessoValidador, string cnpjLoja)
        {
            try
            {
                //Montagem do XML
                Random ram = new Random();
                int identificador = ram.Next(999999, 999999999);
                string xmlEnviarStatusPagamento = IntegradorXml.VerificarStatusValidadorVFPe(identificador.ToString(), chaveAcessoValidador, RetornoVFPE.IdPagamento.ToString(), cnpjLoja);

                //Verificando a existência das Pastas do Integrador e limpando as sujeiras de outros processos
                VerificacaoPastasIntegrador("VerificarStatusValidador");

                DateTime dataHora = DateTime.Now;

                //Gravando na Pasta Input
                using (StreamWriter stream = new StreamWriter(PastaImput + "\\Ler\\VerificarStatusValidador" + identificador + ".TMP"))
                {
                    stream.WriteLine(xmlEnviarStatusPagamento);
                    stream.Close();
                }
                while (!File.Exists(PastaImput + "\\Ler\\VerificarStatusValidador" + identificador + ".TMP"))
                { }
                File.Copy(PastaImput + "\\Ler\\VerificarStatusValidador" + identificador + ".TMP", PastaImput + "\\" + Criptografia.MD5("VerificarStatusValidador" + identificador + dataHora.TimeOfDay.ToString()) + ".xml");

                //Realizando a Leitura da Pasta OutPut
                XmlDocument xmlRetorno = LeituraArquivoRetornoIntegrador(dataHora, identificador.ToString());
                //Tratando os Dados de Retorno
                RetornosMFE retornosMFE = TratandoRetornoVFPe(xmlRetorno);
                if (retornosMFE.VFeRealizada())
                {
                    XmlDocument XMLDoc = new XmlDocument();
                    using (var reader = XmlReader.Create(retornosMFE.MensagemRetornoCompleto))
                    {
                        XMLDoc.Load(reader);
                    }
                    XmlNode nodeAutorizacao = XMLDoc.SelectSingleNode("CodigoAutorizacao");
                    RetornoVFPE.Autorizacao = nodeAutorizacao != null ? nodeAutorizacao.InnerText : "";
                    XmlNode nodeBin = XMLDoc.SelectSingleNode("Bin");
                    RetornoVFPE.BinCartao = nodeBin != null ? nodeBin.InnerText : "";
                    XmlNode nodeDonoCartao = XMLDoc.SelectSingleNode("DonoCartao");
                    RetornoVFPE.DonoCartao = nodeDonoCartao != null ? nodeDonoCartao.InnerText : "";
                    XmlNode nodeDataExpiracao = XMLDoc.SelectSingleNode("DataExpiracao");
                    RetornoVFPE.DataExpiracao = nodeDataExpiracao != null ? nodeDataExpiracao.InnerText : "";
                    XmlNode nodeInstituicaoFinanceira = XMLDoc.SelectSingleNode("InstituicaoFinanceira");
                    RetornoVFPE.Adquirente = nodeInstituicaoFinanceira != null ? nodeInstituicaoFinanceira.InnerText : "";
                    XmlNode nodeParcelas = XMLDoc.SelectSingleNode("Parcelas");
                    RetornoVFPE.QtdParcelas = nodeParcelas != null ? Convert.ToInt32(nodeParcelas.InnerText) : 1;
                    XmlNode nodeUltimosQuatroDigitos = XMLDoc.SelectSingleNode("UltimosQuatroDigitos");
                    RetornoVFPE.UltimosQuatroDigitos = nodeUltimosQuatroDigitos != null ? nodeUltimosQuatroDigitos.InnerText : "";
                    XmlNode nodeCodigoPagamento = XMLDoc.SelectSingleNode("CodigoPagamento");
                    RetornoVFPE.NSU = nodeCodigoPagamento != null ? nodeCodigoPagamento.InnerText : "";
                    XmlNode nodeValorPagamento = XMLDoc.SelectSingleNode("ValorPagamento");
                    RetornoVFPE.ValorCartao = nodeValorPagamento != null ? Convert.ToDecimal(nodeValorPagamento.InnerText.Replace(".", ",")) : 0;
                    XmlNode nodeTipo = XMLDoc.SelectSingleNode("Tipo");
                    RetornoVFPE.Bandeira = nodeTipo != null ? nodeTipo.InnerText : "";
                    RetornoVFPE.MfeEnviadoDadosCartao = true;
                }
                else //Erro no Envio Status do Pagamento
                    RetornoVFPE.MfeEnviadoDadosCartao = false;

                    return retornosMFE;
            }
            catch (Exception ex)
            {
                //Retornando o Erro
                return new RetornosMFE(0, ex.Message);
            }
        }

        #endregion

        #region Métodos de Apoio
        private string GerarChaveRequisicao(string cnpjLoja, string cnpjAdministradora)
        {
            string cnpjContribuinte = Texto.SomenteNumeros(cnpjLoja);
            string cnpjAdquirente = Texto.SomenteNumeros(cnpjAdministradora);
            string chave = Criptografia.MD5(cnpjContribuinte + cnpjAdquirente);

            return chave.Substring(0, 8) + "-" + chave.Substring(8, 4) + "-" + chave.Substring(12, 4) + "-" + chave.Substring(16, 4) + "-" + chave.Substring(20, 12);
        }

        private void VerificacaoPastasIntegrador(string metodo)
        {
            try
            {
                if (!Directory.Exists(PastaImput))
                    throw new Exception("Pasta " + PastaImput + " não Encontrada");
                if (!Directory.Exists(PastaOutput))
                    throw new Exception("Pasta " + PastaOutput + " não Encontrada");
                if (!Directory.Exists(PastaOutput + "\\Lido\\"))
                    Directory.CreateDirectory(PastaOutput + "\\Lido\\");
                string[] dirsOut = Directory.GetFiles(PastaOutput + "\\Lido\\", "*.xml");
                if (dirsOut.Length > 0)
                    for (int i = 0; i < dirsOut.Length; i++)
                        if (File.GetLastWriteTime(dirsOut[i]) < DateTime.Now.AddDays(-3))
                            File.Delete(dirsOut[i]);
                dirsOut = Directory.GetFiles(PastaOutput, "*.xml");
                if (dirsOut.Length > 0)
                    for (int i = 0; i < dirsOut.Length; i++)
                        if (File.GetLastWriteTime(dirsOut[i]) < DateTime.Now.AddDays(-3))
                            File.Delete(dirsOut[i]);

                if (!Directory.Exists(PastaImput + "\\Ler\\"))
                    Directory.CreateDirectory(PastaImput + "\\Ler\\");
                string[] dirsIn = Directory.GetFiles(PastaImput + "\\Ler\\", metodo + "_" + "*.TMP");
                if (dirsIn.Length > 0)
                    for (int i = 0; i < dirsIn.Length; i++)
                        if (File.GetLastWriteTime(dirsIn[i]) < DateTime.Now.AddDays(-3))
                            File.Delete(dirsIn[i]);
                dirsIn = Directory.GetFiles(PastaImput, "*.xml");
                if (dirsIn.Length > 0)
                    for (int i = 0; i < dirsIn.Length; i++)
                        if (File.GetLastWriteTime(dirsIn[i]) < DateTime.Now.AddDays(-3))
                            File.Delete(dirsIn[i]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private XmlDocument LeituraArquivoRetornoIntegrador(DateTime dataHora, string identificador)
        //{
        //    try
        //    {
        //        //Realizando a Leitura da Pasta OutPut para ver o resultado
        //        List<string> arquivos;
        //        int tentativas = 0;
        //        do
        //        {
        //            arquivos = Directory.GetFiles(PastaOutput).Where(x => new FileInfo(x).LastWriteTime >= dataHora.AddMinutes(-10)).ToList();

        //            foreach (string arquivo in arquivos)
        //            {
        //                XmlDocument XMLDoc = new XmlDocument();
        //                using (var reader = XmlReader.Create(arquivo))
        //                {
        //                    XMLDoc.Load(reader);
        //                }
        //                XmlNode node = XMLDoc.SelectSingleNode("/Integrador/Identificador");
        //                if (node == null)
        //                {
        //                    File.Delete(arquivo);
        //                    continue;
        //                }
        //                if (node.InnerText == identificador)
        //                {
        //                    XMLDoc.Save(arquivo.Replace(PastaOutput, PastaOutput + "\\Lido\\"));
        //                    File.Delete(arquivo);
        //                    return XMLDoc;
        //                }
        //            }
        //            tentativas += 1;
        //            Thread.Sleep(1000);

        //        } while (arquivos.Count < 1 && tentativas <= 25);

        //        throw new Exception("Integrador Fiscal está fechado ou não retornou o processo");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        private XmlDocument LeituraArquivoRetornoIntegrador(DateTime dataHora, string identificador)
        {
            try
            {
                //Realizando a Leitura da Pasta OutPut para ver o resultado
                List<string> arquivos;
                int tentativas = 0;
                do
                {
                    arquivos = Directory.GetFiles(PastaOutput).Where(x => new FileInfo(x).LastWriteTime >= dataHora.AddMinutes(-30)).ToList();

                    foreach (string arquivo in arquivos)
                    {
                        XmlDocument XMLDoc = new XmlDocument();
                        using (var reader = XmlReader.Create(arquivo))
                        {
                            XMLDoc.Load(reader);
                        }
                        XmlNode node = XMLDoc.SelectSingleNode("/Integrador/Identificador");
                        if (node == null)
                        {
                            File.Delete(arquivo);
                            continue;
                        }
                        if (node.InnerText == identificador)
                        {
                            XMLDoc.Save(arquivo.Replace(PastaOutput, PastaOutput + "\\Lido\\"));
                            File.Delete(arquivo);
                            return XMLDoc;
                        }
                    }
                    tentativas += 1;
                    Thread.Sleep(1000);

                } while (tentativas <= 60);

                throw new Exception("Integrador Fiscal está fechado ou não retornou o processo");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private RetornosMFE TratandoRetornoIntegrador(XmlDocument xmlRetorno)
        {
            try
            {
                XmlNode nodeResposta = xmlRetorno.SelectSingleNode("/Integrador/IntegradorResposta/Codigo");
                if (nodeResposta != null && nodeResposta.InnerText == "AP")
                {
                    XmlNode nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Resposta/retorno");
                    string[] texto = nodeIdPagamento.InnerText.Split('|');
                    if (texto.Length >= 4)
                        return new RetornosMFE(Convert.ToInt32(texto[1]), texto.Length == 4 ? texto[2] : texto[3], nodeIdPagamento.InnerText);
                    else
                    {
                        if (texto.Length > 1)
                            return new RetornosMFE(Convert.ToInt32(texto[1]), nodeIdPagamento.InnerText);
                        else
                            return new RetornosMFE(0, nodeIdPagamento.InnerText);
                    }
                }
                else
                {
                    XmlNode nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Resposta/retorno");
                    if (nodeIdPagamento != null)
                        return new RetornosMFE(0, nodeIdPagamento.InnerText);
                    nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Erro/Valor");
                    if (nodeIdPagamento != null)
                        return new RetornosMFE(0, nodeIdPagamento.InnerText);
                    nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/");
                    return new RetornosMFE(0, nodeIdPagamento.InnerText);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private RetornosMFE TratandoRetornoVFPe(XmlDocument xmlRetorno)
        {
            try
            {
                XmlNode nodeResposta = xmlRetorno.SelectSingleNode("/Integrador/IntegradorResposta/Codigo");
                if (nodeResposta != null && nodeResposta.InnerText == "AP")
                {
                    XmlNode nodeRetorno = xmlRetorno.SelectSingleNode("/Integrador/Resposta");

                    XmlNode nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Resposta/IdPagamento");
                    if (nodeIdPagamento != null)
                    {
                        XmlNode nodeIdLocal = xmlRetorno.SelectSingleNode("/Integrador/Resposta/StatusPagamento");
                        bool idLocal = nodeIdLocal.InnerText == "EnviadoAoValidador" ? false : true;
                        XmlNode nodeMensagem = xmlRetorno.SelectSingleNode("/Integrador/Resposta/Mensagem");

                        return new RetornosMFE(1, nodeMensagem.InnerText, nodeIdPagamento.InnerText + "|" + idLocal.ToString());
                    }
                    XmlNode nodeVerificarStatus = xmlRetorno.SelectSingleNode("/Integrador/Resposta/IdFila");
                    if (nodeVerificarStatus != null)
                    {
                        if (nodeVerificarStatus.InnerText == "0") 
                            return new RetornosMFE(0, nodeRetorno.OuterXml);
                        else
                            return new RetornosMFE(1, nodeRetorno.OuterXml);
                    }

                    nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Resposta/retorno");
                    if (nodeIdPagamento != null)
                        return new RetornosMFE(1, nodeIdPagamento.InnerText);
                    return new RetornosMFE(0, nodeRetorno.OuterXml);
                }
                else
                {
                    XmlNode nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Resposta/retorno");
                    if (nodeIdPagamento != null)
                        return new RetornosMFE(0, nodeIdPagamento.InnerText);
                    nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/Erro/Valor");
                    if (nodeIdPagamento != null)
                        return new RetornosMFE(0, nodeIdPagamento.InnerText);
                    nodeIdPagamento = xmlRetorno.SelectSingleNode("/Integrador/");
                    return new RetornosMFE(0, nodeIdPagamento.InnerText);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
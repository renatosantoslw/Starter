using System.Xml;

namespace IntegracaoMFE.XML
{
    public static class IntegradorXml
    {
        public static string ConsultarMfeXml(string numeroSessao, string identificador)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "MF-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "ConsultarMFe";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "numeroSessao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", numeroSessao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml;
        }

        public static string ConsultarStatusOperacionalXml(string numeroSessao, string identificador)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "MF-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "ConsultarStatusOperacional";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "numeroSessao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", numeroSessao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml;
        }
        
        public static string EnviarDadosVendaXml(string numeroSessao, string identificador, string codigoAtivacao, string xmlMfe)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "MF-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "EnviarDadosVenda";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "numeroSessao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", numeroSessao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "codigoDeAtivacao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", codigoAtivacao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "dadosVenda", xmldoc));
            xmlParametroParam.AppendChild(newElementXML("Parametro", "Valor", "<![CDATA[" + xmlMfe + "]]>", xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml;
        }

        public static string CancelarUltimaVendaXml(string numeroSessao, string identificador, string codigoAtivacao, string chaveAcesso, string xmlCfeCanc)
        {

            // Montagem do XML do Integrador
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "MF-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "CancelarUltimaVenda";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "numeroSessao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", numeroSessao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "codigoDeAtivacao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", codigoAtivacao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "chave", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", chaveAcesso, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "dadosCancelamento", xmldoc));
            xmlParametroParam.AppendChild(newElementXML("Parametro", "Valor", "<![CDATA[" + xmlCfeCanc + "]]>", xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml.ToString();
        }

        public static string EnviarPagamentoVFPe(string identificador, string chaveAcessoValidador, string chaveRequisicao, string estabelecimento, string serialPos,
                                                 string cnpjLoja, decimal baseIcms, decimal valorTotalVenda, string origemPagamento, bool habilitarMultiplosPagamentos = true,
                                                 bool habilitarControleAntiFraude = false, bool emitirCupomNfce = false, string codigoMoeda = "BRL")
        {

            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "VFP-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "EnviarPagamento";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlConstrutor = xmldoc.CreateElement("", "Construtor", null);
            XmlNode xmlParametrosCons = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroCons = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroCons.AppendChild(newElement("Parametro", "Nome", "chaveAcessoValidador", xmldoc));
            xmlParametroCons.AppendChild(newElement("Parametro", "Valor", chaveAcessoValidador, xmldoc));

            xmlParametrosCons.AppendChild(xmlParametroCons); //Adicionando xmlParametroCons a xmlParametrosCons
            xmlConstrutor.AppendChild(xmlParametrosCons); //Adicionando xmlParametrosCons a xmlConstrutor

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "ChaveRequisicao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", chaveRequisicao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Estabelecimento", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", estabelecimento.Length > 9 ? estabelecimento.Substring(estabelecimento.ToString().Length - 9) : estabelecimento, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "SerialPos", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", serialPos, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Cnpj", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", cnpjLoja, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "IcmsBase", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", baseIcms.ToString("N2"), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "ValorTotalVenda", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", valorTotalVenda.ToString("N2"), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "HabilitarMultiplosPagamentos", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", habilitarMultiplosPagamentos.ToString().ToLower(), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "HabilitarControleAntiFraude", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", habilitarControleAntiFraude.ToString().ToLower(), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "CodigoMoeda", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", codigoMoeda, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "EmitirCupomNFCE", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", emitirCupomNfce.ToString().ToLower(), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "OrigemPagamento", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", origemPagamento, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam


            xmlMetodo.AppendChild(xmlConstrutor); //Adicionando xmlConstrutor a xmlMetodo
            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml.ToString();
        }

        public static string EnviarStatusPagamentoVFPe(string identificador, string chaveAcessoValidador, string autorizacao, string binCartao, string adquirente, int qtdParcelas,
                                                       string nsu, decimal valorCartao, string idPagamento, string bandeira, string ultimo4DigitosCartao)
        {

            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "VFP-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "EnviarStatusPagamento";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlConstrutor = xmldoc.CreateElement("", "Construtor", null);
            XmlNode xmlParametrosCons = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroCons = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroCons.AppendChild(newElement("Parametro", "Nome", "chaveAcessoValidador", xmldoc));
            xmlParametroCons.AppendChild(newElement("Parametro", "Valor", chaveAcessoValidador, xmldoc));

            xmlParametrosCons.AppendChild(xmlParametroCons); //Adicionando xmlParametroCons a xmlParametrosCons
            xmlConstrutor.AppendChild(xmlParametrosCons); //Adicionando xmlParametrosCons a xmlConstrutor

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "CodigoAutorizacao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", string.IsNullOrEmpty(autorizacao) ? "000000" : autorizacao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Bin", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", string.IsNullOrEmpty(binCartao) ? "000000" : binCartao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "DonoCartao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", "indefinido", xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "DataExpiracao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", "0000", xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "InstituicaoFinanceira", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", adquirente, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Parcelas", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", qtdParcelas.ToString(), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "CodigoPagamento", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", nsu, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "ValorPagamento", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", valorCartao.ToString("0.00"), xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "IdFila", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", idPagamento, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Tipo", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", bandeira, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "UltimosQuatroDigitos", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", string.IsNullOrEmpty(ultimo4DigitosCartao)? "0000" : ultimo4DigitosCartao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam


            xmlMetodo.AppendChild(xmlConstrutor); //Adicionando xmlConstrutor a xmlMetodo
            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml.ToString();

        }

        public static string RespostaFiscalVFPe(string identificador, string chaveAcessoValidador, string idPagamento, string chaveAcessoCfe, string nsu, string autorizacao, string bandeira,
                                                string adquirente, string cnpjLoja, string notaFiscal, string ImpresaoFiscal)
        {

            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "VFP-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "RespostaFiscal";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlConstrutor = xmldoc.CreateElement("", "Construtor", null);
            XmlNode xmlParametrosCons = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroCons = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroCons.AppendChild(newElement("Parametro", "Nome", "chaveAcessoValidador", xmldoc));
            xmlParametroCons.AppendChild(newElement("Parametro", "Valor", chaveAcessoValidador, xmldoc));

            xmlParametrosCons.AppendChild(xmlParametroCons); //Adicionando xmlParametroCons a xmlParametrosCons
            xmlConstrutor.AppendChild(xmlParametrosCons); //Adicionando xmlParametrosCons a xmlConstrutor

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "idFila", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", idPagamento, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "ChaveAcesso", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", chaveAcessoCfe, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Nsu", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", nsu, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "NumerodeAprovacao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", string.IsNullOrEmpty(autorizacao) ? "0" : autorizacao, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Bandeira", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", bandeira, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Adquirente", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", adquirente, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "Cnpj", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", cnpjLoja, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "ImpressaoFiscal", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", ImpresaoFiscal, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "NumeroDocumento", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", notaFiscal, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlMetodo.AppendChild(xmlConstrutor); //Adicionando xmlConstrutor a xmlMetodo
            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml.ToString();

        }

        public static string VerificarStatusValidadorVFPe(string identificador, string chaveAcessoValidador, string idPagamento, string cnpjLoja)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "VFP-e";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "VerificarStatusValidador";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlConstrutor = xmldoc.CreateElement("", "Construtor", null);
            XmlNode xmlParametrosCons = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroCons = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroCons.AppendChild(newElement("Parametro", "Nome", "chaveAcessoValidador", xmldoc));
            xmlParametroCons.AppendChild(newElement("Parametro", "Valor", chaveAcessoValidador, xmldoc));

            xmlParametrosCons.AppendChild(xmlParametroCons); //Adicionando xmlParametroCons a xmlParametrosCons
            xmlConstrutor.AppendChild(xmlParametrosCons); //Adicionando xmlParametrosCons a xmlConstrutor

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "idFila", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", idPagamento, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "cnpj", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", cnpjLoja, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam

            xmlMetodo.AppendChild(xmlConstrutor); //Adicionando xmlConstrutor a xmlMetodo
            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc
            
            return xmldoc.OuterXml.ToString();
        }

        public static string ConsultaNumeroSessao(string identificador, string numeroSessaoConsultar)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmlnode);
            xmlnode = xmldoc.CreateElement("", "Integrador", null);

            XmlNode xmlIdentificador = xmldoc.CreateElement("", "Identificador", null);
            xmlIdentificador.AppendChild(newElement("Identificador", "Valor", identificador, xmldoc));

            XmlNode xmlComponente = xmldoc.CreateElement("", "Componente", null);
            XmlAttribute att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "ConsultaNumeroSessao";
            xmlComponente.Attributes.Append(att);

            XmlNode xmlMetodo = xmldoc.CreateElement("", "Metodo", null);
            att = xmldoc.CreateAttribute("Nome");
            att.InnerText = "numeroSessao";
            xmlMetodo.Attributes.Append(att);

            XmlNode xmlParametrosParam = xmldoc.CreateElement("", "Parametros", null);

            XmlNode xmlParametroParam = xmldoc.CreateElement("", "Parametro", null);
            xmlParametroParam.AppendChild(newElement("Parametro", "Nome", "numeroSessao", xmldoc));
            xmlParametroParam.AppendChild(newElement("Parametro", "Valor", numeroSessaoConsultar, xmldoc));
            xmlParametrosParam.AppendChild(xmlParametroParam); //Adicionando xmlParametroParam a xmlParametrosParam


            xmlMetodo.AppendChild(xmlParametrosParam); //Adicionando xmlParametrosParam a xmlMetodo
            xmlComponente.AppendChild(xmlMetodo); //Adicionando xmlMetodo a xmlComponente
            xmlnode.AppendChild(xmlIdentificador); //Adicionando Identificador a xmlnode Integrador
            xmlnode.AppendChild(xmlComponente); //Adicionando xmlComponente a xmlnode Integrador
            xmldoc.AppendChild(xmlnode); //Adicionando xmlnode Integrador a xmlDoc

            return xmldoc.OuterXml;
        }
        
        private static XmlNode newElement(string tagprc, string newtag, string conteud, XmlDocument xmldoc)
        {
            XmlNode xmlnode = xmldoc.CreateElement(tagprc, newtag, null);
            xmlnode.InnerText = conteud;

            return xmlnode;
        }

        private static XmlNode newElementXML(string tagprc, string newtag, string conteud, XmlDocument xmldoc)
        {
            XmlNode xmlnode = xmldoc.CreateElement(tagprc, newtag, null);
            xmlnode.InnerXml = conteud;

            return xmlnode;
        }

    }
}

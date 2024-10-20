using DFe.Utils;
using MDFe.Classes.Extencoes;
using MDFe.Classes.Flags;
using MDFe.Classes.Informacoes;
using MDFe.Classes.Retorno;
using MDFe.Classes.Retorno.MDFeEvento;
using MDFe.Classes.Retorno.MDFeRetRecepcao;
using MDFe.Damdfe.Base;
using MDFe.Damdfe.Fast;
using MDFe.Servicos.EventosMDFe;
using MDFe.Servicos.RecepcaoMDFe;
using MDFe.Servicos.RetRecepcaoMDFe;
using MDFe.Utils.Configuracoes;
using NFe.Utils.Excecoes;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.MDFE.Configuracao;
using PDV.CONTROLLER.MDFE.Util;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.MDFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace PDV.CONTROLLER.MDFE.Eventos
{
    public class EventosMDFe
    {
        public static RetornoTransmissaoMDFe TransmitirMDFe(ManifestoDocumentoFiscalEletronico Manifesto, decimal? IDMovimentoFiscalMDFe, string CaminhoSchemas)
        {
            MDFe.Classes.Informacoes.MDFe MDFe = null;
            MDFeProcMDFe MDFeComProtocolo = null;
            try
            {
                ConfigMDFe.PreencheConfiguracao(CaminhoSchemas);
                MDFe = CarregarMDFe(Manifesto);
                MDFe = MDFe.Assina();
                MDFe = MDFe.Valida();

                MDFeComProtocolo = new MDFeProcMDFe
                {
                    MDFe = MDFe,
                    ProtMDFe = GetProtocolo(new ServicoMDFeRecepcao().MDFeRecepcao(1, MDFe).InfRec.NRec)
                };
            }
            catch (ComunicacaoException ex)
            {
                return new RetornoTransmissaoMDFe
                {
                    isAutorizada = false,
                    isSchemaValido = true,
                    Motivo = ex.Message
                };
            }
            catch (ValidacaoSchemaException Ex)
            {
                return new RetornoTransmissaoMDFe
                {
                    isAutorizada = false,
                    isSchemaValido = false,
                    Motivo = Ex.Message
                };
            }
            catch (Exception Ex)
            {
                return new RetornoTransmissaoMDFe
                {
                    isAutorizada = false,
                    isSchemaValido = true,
                    Motivo = Ex.Message
                };
            }

            /* Salvar/Atualizar o MDFe */
            decimal _IDMovimentoFiscalMDFe = IDMovimentoFiscalMDFe.HasValue ? IDMovimentoFiscalMDFe.Value : Sequence.GetNextID("MOVIMENTOFISCALMDFE", "IDMOVIMENTOFISCALMDFE");
            if (!FuncoesMovimentoFiscalMDFe.Salvar(new MovimentoFiscalMDFe
            {
                Ambiente = Manifesto.TipoAmbiente,
                Cancelada = 0,
                Chave = MDFeComProtocolo.ProtMDFe.InfProt.ChMDFe,
                CSTAT = MDFeComProtocolo.ProtMDFe.InfProt.CStat,
                Motivo = MDFeComProtocolo.ProtMDFe.InfProt.XMotivo,
                Emissao = MDFeComProtocolo.MDFe.InfMDFe.Ide.DhEmi,
                Recebimento = MDFeComProtocolo.ProtMDFe.InfProt.DhRecbto,
                Emitida = 1,
                Encerrada = 0,
                IDMDFe = Manifesto.IDMDFe,
                IDMovimentoFiscalMDFe = _IDMovimentoFiscalMDFe,
                Numero = Manifesto.NMDF,
                Serie = Manifesto.Serie,
                TipoDocumento = (int)DFe.Classes.Flags.ModeloDocumento.MDFe,
                XmlEnvio = Encoding.Default.GetBytes(FuncoesXml.ClasseParaXmlString(MDFe)),
                XmlRetorno = Encoding.Default.GetBytes(FuncoesXml.ClasseParaXmlString(MDFeComProtocolo))
            }, !IDMovimentoFiscalMDFe.HasValue ? DAO.Enum.TipoOperacao.INSERT : DAO.Enum.TipoOperacao.UPDATE))
                throw new Exception("Não foi possível salvar o movimento do MDFe.");

            return new RetornoTransmissaoMDFe
            {
                IDMDFe = Manifesto.IDMDFe,
                IDMovimentoFiscalMDFe = _IDMovimentoFiscalMDFe,
                isAutorizada = MDFeComProtocolo.ProtMDFe.InfProt.CStat == 100,
                MDFeComProtocolo = MDFeComProtocolo,
                Motivo = MDFeComProtocolo.ProtMDFe.InfProt.XMotivo,
                isSchemaValido = true,
                Danfe = GetDamfeMDFe(MDFeComProtocolo),
                isCaixaDialogo = ConfigMDFe.IsExibirCaixaDialogo(),
                NomeImpressora = ConfigMDFe.GetNomeImpressora()
            };
        }

        private static MDFeProtMDFe GetProtocolo(string NRec)
        {
            Thread.Sleep(5000);
            return new ServicoMDFeRetRecepcao().MDFeRetRecepcao(NRec).ProtMdFe;
        }

        private static DamdfeFrMDFe GetDamfeMDFe(MDFeProcMDFe mdfe)
        {
            return new DamdfeFrMDFe(proc: mdfe,
                config: new ConfiguracaoDamdfe()
                {
                    Logomarca = FuncoesEmitente.GetEmitente().Logomarca,
                    DocumentoEncerrado = false,
                    DocumentoCancelado = false,
                    Desenvolvedor = "DUE ERP - Ebenezer Software",
                    QuebrarLinhasObservacao = true
                });
        }

        public static RetornoTransmissaoMDFe EncerrarMDFe(decimal IDMovimentoFiscalMDFe)
        {
            MovimentoFiscalMDFe Movimento = FuncoesMovimentoFiscalMDFe.GetMovimento(IDMovimentoFiscalMDFe);
            MDFeProcMDFe MDFeProc = FuncoesXml.XmlStringParaClasse<MDFeProcMDFe>(Encoding.UTF8.GetString(Movimento.XmlRetorno));
            int ProxCod = FuncoesEventoMDFe.GetProxSeqEvento(IDMovimentoFiscalMDFe, 2);

            MDFeRetEventoMDFe RetornoEvento = new ServicoMDFeEvento().MDFeEventoEncerramentoMDFeEventoEncerramento(MDFeProc.MDFe, (byte)ProxCod, MDFeProc.ProtMDFe.InfProt.NProt);
            if (RetornoEvento.InfEvento.CStat == 135)
            {
                if (!FuncoesEventoMDFe.Salvar(new EventoMDFE
                {
                    CSTAT = RetornoEvento.InfEvento.CStat,
                    DescEvento = RetornoEvento.InfEvento.XEvento,
                    DHEvento = RetornoEvento.InfEvento.DhRegEvento,
                    IDEventoMDFE = Sequence.GetNextID("EVENTOMDFE", "IDEVENTOMDFE"),
                    IDMovimentoFiscalMDFe = IDMovimentoFiscalMDFe,
                    NProt = RetornoEvento.InfEvento.NProt,
                    NSeqEvento = ProxCod,
                    TipoEvento = 2,
                    XMotivo = RetornoEvento.InfEvento.XMotivo
                }))
                    throw new Exception("Não foi possível salvar o Encerramento do MDFe.");

                if (!FuncoesMovimentoFiscalMDFe.Encerrar(IDMovimentoFiscalMDFe))
                    throw new Exception("Não foi possível salvar o Encerramento do MDFe.");
            }
            else
                throw new Exception(RetornoEvento.InfEvento.XMotivo);

            return new RetornoTransmissaoMDFe
            {
                isAutorizada = true,
                Motivo = RetornoEvento.InfEvento.XMotivo
            };
        }

        public static RetornoTransmissaoMDFe CancelarMDFe(decimal IDMovimentoFiscalMDFe)
        {
            MovimentoFiscalMDFe Movimento = FuncoesMovimentoFiscalMDFe.GetMovimento(IDMovimentoFiscalMDFe);
            MDFeProcMDFe MDFeProc = FuncoesXml.XmlStringParaClasse<MDFeProcMDFe>(Encoding.UTF8.GetString(Movimento.XmlRetorno));
            int ProxCod = FuncoesEventoMDFe.GetProxSeqEvento(IDMovimentoFiscalMDFe, 1);

            MDFeRetEventoMDFe RetornoEvento = new ServicoMDFeEvento().MDFeEventoEncerramentoMDFeEventoEncerramento(MDFeProc.MDFe, (byte)ProxCod, MDFeProc.ProtMDFe.InfProt.NProt);
            if (RetornoEvento.InfEvento.CStat == 135)
            {
                if (!FuncoesEventoMDFe.Salvar(new EventoMDFE
                {
                    CSTAT = RetornoEvento.InfEvento.CStat,
                    DescEvento = RetornoEvento.InfEvento.XEvento,
                    DHEvento = RetornoEvento.InfEvento.DhRegEvento,
                    IDEventoMDFE = Sequence.GetNextID("EVENTOMDFE", "IDEVENTOMDFE"),
                    IDMovimentoFiscalMDFe = IDMovimentoFiscalMDFe,
                    NProt = RetornoEvento.InfEvento.NProt,
                    NSeqEvento = ProxCod,
                    TipoEvento = 1,
                    XMotivo = RetornoEvento.InfEvento.XMotivo
                }))
                    throw new Exception("Não foi possível salvar o Cancelamento do MDFe.");

                if (!FuncoesMovimentoFiscalMDFe.Cancelar(IDMovimentoFiscalMDFe))
                    throw new Exception("Não foi possível salvar o Cancelamento do MDFe.");
            }
            else
                throw new Exception(RetornoEvento.InfEvento.XMotivo);

            return new RetornoTransmissaoMDFe
            {
                isAutorizada = true,
                Motivo = RetornoEvento.InfEvento.XMotivo
            };
        }

        /* Métodos de Carregamento do MDFe */
        private static MDFeEmit GetEmitente()
        {
            Emitente Emitente = FuncoesEmitente.GetEmitente();
            Endereco EnderecoEmitente = FuncoesEndereco.GetEndereco(Emitente.IDEndereco);
            Municipio MunicipioEmitente = FuncoesMunicipio.GetMunicipio(EnderecoEmitente.IDMunicipio.Value);
            UnidadeFederativa UFEmitente = FuncoesUF.GetUnidadeFederativa(EnderecoEmitente.IDUnidadeFederativa.Value);

            return new MDFeEmit()
            {
                CNPJ = Emitente.CNPJ,
                IE = Emitente.InscricaoEstadual,
                XFant = Emitente.NomeFantasia,
                XNome = Emitente.RazaoSocial,
                EnderEmit = new MDFeEnderEmit()
                {
                    CEP = Convert.ToInt32(EnderecoEmitente.Cep),
                    CMun = (long)Convert.ToDecimal(MunicipioEmitente.CodigoIBGE),
                    Fone = EnderecoEmitente.Telefone,
                    Nro = EnderecoEmitente.Numero,
                    UF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), UFEmitente.Sigla),
                    XBairro = EnderecoEmitente.Bairro,
                    XCpl = EnderecoEmitente.Complemento,
                    XLgr = EnderecoEmitente.Logradouro,
                    XMun = MunicipioEmitente.Descricao
                }
            };
        }

        private static MDFe.Classes.Informacoes.MDFe CarregarMDFe(ManifestoDocumentoFiscalEletronico ManifestoFiscal)
        {
            MDFe.Classes.Informacoes.MDFe Manifesto = new MDFe.Classes.Informacoes.MDFe();
            Manifesto.InfMDFe.Emit = GetEmitente();
            Manifesto.InfMDFe.Ide = new MDFeIde
            {

                CUF = Manifesto.InfMDFe.Emit.EnderEmit.UF,
                TpAmb = MDFeConfiguracao.VersaoWebService.TipoAmbiente,
                TpTransp = (MDFeTpTransp)Enum.Parse(typeof(MDFeTpTransp), ManifestoFiscal.TipoTransportador.ToString()),
                TpEmit = (MDFeTipoEmitente)Enum.Parse(typeof(MDFeTipoEmitente), ManifestoFiscal.TipoEmitente.ToString()),
                Mod = DFe.Classes.Flags.ModeloDocumento.MDFe,
                Serie = (short)ManifestoFiscal.Serie,
                NMDF = (long)ManifestoFiscal.NMDF,
                CMDF = GetRandom(),
                Modal = MDFeModal.Rodoviario,
                DhEmi = DateTime.Now,
                TpEmis = MDFeTipoEmissao.Normal,
                VerProc = "3.0",
                ProcEmi = MDFeIdentificacaoProcessoEmissao.EmissaoComAplicativoContribuinte,
                UFIni = Manifesto.InfMDFe.Emit.EnderEmit.UF,
                UFFim = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesUF.GetUnidadeFederativa(ManifestoFiscal.IDUnidadeFederativaDescarregamento).Sigla),
                InfPercurso = GetPercurso(ManifestoFiscal.IDMDFe),
                InfMunCarrega = GetCarregamento(),
            };

            Manifesto.InfMDFe.Seg = GetSeguro(ManifestoFiscal);

            if (Manifesto.InfMDFe.Ide.TpEmit == MDFeTipoEmitente.TransportadorCargaPropria)
                Manifesto.InfMDFe.Ide.TpTransp = null;

            Manifesto.InfMDFe.InfDoc = new MDFeInfDoc
            {
                InfMunDescarga = GetDescarregamento(ManifestoFiscal.IDMDFe)
            };

            Manifesto.InfMDFe.InfAdic = new MDFeInfAdic
            {
                InfCpl = string.IsNullOrEmpty(ManifestoFiscal.InformacoesComplementares) ? null : ManifestoFiscal.InformacoesComplementares
            };

            Manifesto.InfMDFe.InfModal = new MDFeInfModal
            {
                VersaoModal = MDFeVersaoModal.Versao300,
                Modal = GetModalRodoviario(ManifestoFiscal)
            };

            Manifesto.InfMDFe.Tot = GetTotal(ManifestoFiscal);
            return Manifesto;
        }

        private static List<MDFeSeg> GetSeguro(ManifestoDocumentoFiscalEletronico ManifestoFiscal)
        {
            List<MDFeSeg> Seguros = new List<MDFeSeg>();
            DataTable dtSeguro = FuncoesSeguradoraMDFe.GetSegurosPorMDFe(ManifestoFiscal.IDMDFe);
            foreach (DataRow dr in dtSeguro.Rows)
            {
                ResponsavelSeguroCargaMDFe ResponsavelCarga = FuncoesResponsavelSeguroCargaMDFe.GetResponsavel(Convert.ToDecimal(dr["IDRESPONSAVELSEGUROCARGAMDFE"]));
                Seguradora Seguradora = FuncoesSeguradora.GetSeguradora(Convert.ToDecimal(dr["IDSEGURADORA"]));
                Seguros.Add(new MDFeSeg
                {
                    InfResp = ResponsavelCarga == null ? null : new MDFeInfResp
                    {
                        RespSeg = (MDFeRespSeg)Enum.Parse(typeof(MDFeRespSeg), ResponsavelCarga.ResponsavelSeguro.ToString()),
                        CNPJ = ResponsavelCarga.CNPJ,
                        CPF = ResponsavelCarga.CPF
                    },
                    InfSeg = new MDFeInfSeg
                    {
                        XSeg = Seguradora.Descricao,
                        CNPJ = Seguradora.CNPJ
                    },
                    NApol = string.IsNullOrEmpty(dr["NUMEROAPOLICE"].ToString()) ? null : dr["NUMEROAPOLICE"].ToString(),
                    NAver = GetAverbacoes(Convert.ToDecimal(dr["IDSEGURADORAMDFE"])),
                });
            }
            return Seguros;
        }

        private static List<string> GetAverbacoes(decimal IDSeguradoraMDFe)
        {
            List<string> Averbacoes = new List<string>();
            DataTable dtAverbacoes = FuncoesAverbacaoMDFe.GetAverbacoes(IDSeguradoraMDFe);
            foreach (DataRow dr in dtAverbacoes.Rows)
                Averbacoes.Add(dr["NUMEROAVERBACAO"].ToString());
            return Averbacoes;
        }

        private static MDFeTot GetTotal(ManifestoDocumentoFiscalEletronico ManifestoFiscal)
        {
            DataTable dtTotal = FuncoesVolume.GetTotalVolumesPorMDFe(ManifestoFiscal.IDMDFe);
            return new MDFeTot
            {
                QCTe = 0,
                CUnid = (MDFeCUnid)Enum.Parse(typeof(MDFeCUnid), ManifestoFiscal.CodigoUNPesoCarga.ToString()),
                vCarga = Convert.ToInt32(dtTotal.Rows[0]["QTDNFE"]) == 0 ? 0 : Convert.ToDecimal(dtTotal.Rows[0]["TOTALNFE"]),
                QNFe = Convert.ToInt32(dtTotal.Rows[0]["QTDNFE"]) == 0 ? 0 : Convert.ToInt32(dtTotal.Rows[0]["QTDNFE"]),
                QCarga = ManifestoFiscal.PesoBrutoTotal
            };
        }

        private static MDFeRodo GetModalRodoviario(ManifestoDocumentoFiscalEletronico MDFe)
        {
            DataTable dtPropVeiculo = FuncoesVeiculoMDFe.GetVeiculoEProprietarioMDFe(MDFe.IDMDFe);
            Veiculo Veiculo = FuncoesVeiculoMDFe.GetVeiculo(Convert.ToDecimal(dtPropVeiculo.Rows[0]["IDVEICULO"]));
            ProprietarioVeiculoMDFe Proprietario = null;
            if (dtPropVeiculo.Rows[0]["IDPROPRIETARIOVEICULOMDFE"] != DBNull.Value)
                Proprietario = FuncoesProprietario.GetProprietario(Convert.ToDecimal(dtPropVeiculo.Rows[0]["IDPROPRIETARIOVEICULOMDFE"]));

            return new MDFeRodo
            {
                CodAgPorto = Proprietario != null && Proprietario.CodigoAgenciaPorto.HasValue ? Proprietario.CodigoAgenciaPorto.Value.ToString() : null,
                VeicTracao = new MDFeVeicTracao
                {
                    CapKG = (int?)Veiculo.CapacidadeEmKG,
                    CapM3 = (int?)Veiculo.CapacidadeEmM3,
                    Placa = string.IsNullOrEmpty(Veiculo.Placa) ? null : Veiculo.Placa,
                    RENAVAM = string.IsNullOrEmpty(Veiculo.Renavam) ? null : Veiculo.Renavam,
                    Tara = (int?)Veiculo.TaraEmKG,
                    TpCar = (MDFeTpCar)Enum.Parse(typeof(MDFeTpCar), Veiculo.TipoCarroceria.ToString()),
                    TpRod = (MDFeTpRod)Enum.Parse(typeof(MDFeTpRod), Veiculo.TipoRodado.ToString()),
                    UF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesUF.GetUnidadeFederativa(Veiculo.IDUnidadefederativa).Sigla),
                    Prop = Proprietario != null && !string.IsNullOrEmpty(Proprietario.RNTRC) ? new MDFeProp
                    {
                        CNPJ = string.IsNullOrEmpty(Proprietario.CNPJ) ? null : Proprietario.CNPJ,
                        CPF = string.IsNullOrEmpty(Proprietario.CPF) ? null : Proprietario.CPF,
                        IE = Proprietario.InscricaoEstadual.HasValue ? Proprietario.InscricaoEstadual.ToString() : null,
                        XNome = Proprietario.Nome,
                        MDFeTpProp = MDFeTpProp.Outros,
                        RNTRC = Proprietario.RNTRC,
                        UF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesUF.GetUnidadeFederativa(Proprietario.IDUnidadeFederativa).Sigla),
                    } : null,
                    Condutor = GetCondutores(MDFe.IDMDFe),
                },
                lacRodo = GetLacres(MDFe.IDMDFe),
                infANTT = new MDFeInfANTT
                {
                    infContratante = GetContratantes(MDFe)
                }
            };
        }

        private static List<infContratante> GetContratantes(ManifestoDocumentoFiscalEletronico MDFe)
        {
            List<infContratante> Contratantes = new List<infContratante>();
            DataTable dtContratantes = FuncoesContratanteMDFe.GetContratantesPorMDFe(MDFe.IDMDFe);
            foreach (DataRow dr in dtContratantes.Rows)
                Contratantes.Add(new infContratante
                {
                    CPF = string.IsNullOrEmpty(dr["CPF"].ToString()) ? null : dr["CPF"].ToString(),
                    CNPJ = string.IsNullOrEmpty(dr["CNPJ"].ToString()) ? null : dr["CNPJ"].ToString()
                });
            return Contratantes;
        }

        private static List<MDFeLacre> GetLacres(decimal IDMDFe)
        {
            List<MDFeLacre> Lacres = new List<MDFeLacre>();
            DataTable dtLacres = FuncoesLacreMDFe.GetLacresPorMDFe(IDMDFe);
            foreach (DataRow dr in dtLacres.Rows)
                Lacres.Add(new MDFeLacre
                {
                    NLacre = dr["NUMERO"].ToString()
                });
            return Lacres;
        }

        private static List<MDFeCondutor> GetCondutores(decimal IDMDFe)
        {
            List<MDFeCondutor> Condutores = new List<MDFeCondutor>();
            DataTable dtCondutores = FuncoesCondutor.GetCondutoresPorMDFe(IDMDFe);
            foreach (DataRow dr in dtCondutores.Rows)
                Condutores.Add(new MDFeCondutor
                {
                    CPF = dr["CPF"].ToString(),
                    XNome = dr["NOME"].ToString()
                });

            return Condutores;
        }

        private static List<MDFeInfMunCarrega> GetCarregamento()
        {
            Municipio MunicipioEmitente = FuncoesMunicipio.GetMunicipio(FuncoesEndereco.GetEndereco(FuncoesEmitente.GetEmitente().IDEndereco).IDMunicipio.Value);
            List<MDFeInfMunCarrega> Carregamentos = new List<MDFeInfMunCarrega>();
            Carregamentos.Add(new MDFeInfMunCarrega()
            {
                CMunCarrega = MunicipioEmitente.CodigoIBGE,
                XMunCarrega = MunicipioEmitente.Descricao
            });
            return Carregamentos;
        }

        private static List<MDFeInfMunDescarga> GetDescarregamento(decimal IDMDFe)
        {
            List<MDFeInfMunDescarga> Descarregamento = new List<MDFeInfMunDescarga>();
            DataTable dtNFe = FuncoesDocumentoFiscalMDFe.GetDocumentosFiscal(IDMDFe);
            foreach (DataRow dr in dtNFe.Rows)
            {
                Municipio MunicipioDescarga = FuncoesMunicipio.GetMunicipio(Convert.ToDecimal(dr["IDMUNICIPIODESCARGA"]));
                if (Descarregamento.Where(o => o.CMunDescarga == MunicipioDescarga.CodigoIBGE).Count() > 0)
                    continue;

                Descarregamento.Add(new MDFeInfMunDescarga
                {
                    CMunDescarga = MunicipioDescarga.CodigoIBGE,
                    XMunDescarga = MunicipioDescarga.Descricao,
                    InfNFe = GetNFe(dtNFe, MunicipioDescarga)
                });
            };
            return Descarregamento;
        }

        private static List<MDFeInfNFe> GetNFe(DataTable dtNFe, Municipio MunicipioDescarga)
        {
            var lQuery = dtNFe.AsEnumerable().Where(o => Convert.ToDecimal(o["IDMUNICIPIODESCARGA"]) == MunicipioDescarga.IDMunicipio);
            if (lQuery != null && lQuery.Count() > 0)
            {
                List<MDFeInfNFe> Infs = new List<MDFeInfNFe>();
                foreach (DataRow dr in lQuery)
                    Infs.Add(new MDFeInfNFe { ChNFe = dr["CHAVENFE"].ToString() });
                return Infs;
            }
            return null;
        }


        private static List<MDFeInfPercurso> GetPercurso(decimal IDMDFe)
        {
            List<MDFeInfPercurso> Percursos = new List<MDFeInfPercurso>();

            DataTable dtPercurso = FuncoesPercurso.GetPercursosPorMDFe(IDMDFe);
            foreach (DataRow dr in dtPercurso.Rows)
                Percursos.Add(new MDFeInfPercurso()
                {
                    UFPer = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), dr["SIGLA"].ToString())
                });
            return Percursos;
        }

        private static int GetRandom()
        {
            var rand = new Random();
            return rand.Next(11111111, 99999999);
        }
    }
}

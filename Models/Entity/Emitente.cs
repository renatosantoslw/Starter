using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Emitente
    {
        public Emitente()
        {
            Emailemitentes = new HashSet<Emailemitente>();
            Mdves = new HashSet<Mdfe>();
        }

        public int Idemitente { get; set; }
        public int? Idendereco { get; set; }
        public string Cnpj { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefantasia { get; set; }
        public string Email { get; set; }
        public decimal? Crt { get; set; }
        public byte[] Certificado { get; set; }
        public string Nomecertificado { get; set; }
        public string Csc { get; set; }
        public string Idcsc { get; set; }
        public string Inscricaomunicipal { get; set; }
        public string Inscricaoestadual { get; set; }
        public byte[] Logomarca { get; set; }
        public string Nomelogomarca { get; set; }
        public string Senhacertificado { get; set; }
        public decimal? Cnae { get; set; }
        public string Chaveerp { get; set; }
        public string Ultimalinhacabecalho { get; set; }
        public string Fone { get; set; }
        public string Datalocal { get; set; }
        public bool? Ativo { get; set; }
        public string Versaoxml { get; set; }
        public string Codigoativacao { get; set; }
        public string Pastainput { get; set; }
        public string Pastaoutput { get; set; }
        public string Cnpjsoftwarehouse { get; set; }
        public string Signac { get; set; }
        public string Cregtribissqn { get; set; }
        public string Indratissqn { get; set; }
        public string Chaveacessovalidador { get; set; }
        public string Pastaxml { get; set; }
        public byte[] Logopropraganda { get; set; }
        public string Nomelogopropraganda { get; set; }
        public int? Proximonumeronfe { get; set; }
        public int? Proximonumeronfce { get; set; }
        public int? Modeloimpressaodav { get; set; }

        public virtual ICollection<Emailemitente> Emailemitentes { get; set; }
        public virtual ICollection<Mdfe> Mdves { get; set; }
    }
}

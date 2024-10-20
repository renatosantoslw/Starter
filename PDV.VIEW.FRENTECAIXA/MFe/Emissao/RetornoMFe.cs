using ACBr.Net.Sat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.FRENTECAIXA.MFe.Emissao
{
    public class RetornoMFe
    {
        public bool Enviado { get; set; }

        public string  Resposta { get; set; }

        public CFe CFe { get; set; }

        public static explicit operator Action<object>(RetornoMFe v)
        {
            throw new NotImplementedException();
        }
    }
}

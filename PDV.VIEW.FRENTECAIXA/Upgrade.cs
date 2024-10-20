using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.FRENTECAIXA
{
    class Upgrade
    {
        private int sVersaoAtual = 0;
        public  string QuotedStr = "\"";
        private void SetClausulas()
        {
            int sAux = 0;

        }
        private void InsereNews(int sVersao, string sTipo, string sData, string sNews)
        {
            string sAux = string.Empty;
            if (sVersao > sVersaoAtual)
                sAux = "insert into sysnews (Versao, Tipo, Data, Descricao) values(" + sVersao.ToString() + "," + sTipo + ',' + sData + ',' + sNews + ")";
           // gStrings.AddObject(sAux, TObject(0))
        }
        private void SetaVersao(string sVersao)
        {

        }
        private void Insere(string sVersao, string sTexto, int iNro)
        {

        }
    }
}

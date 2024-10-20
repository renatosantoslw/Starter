using NFe.Utils.NFe;
using PDV.CONTROLLER.NFE.Impressao;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW
{
    public partial class viewXMLcs : Form
    {
        public NFe.Classes.NFe _nfe;
        private readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public viewXMLcs(NFe.Classes.NFe nfe)
        {
            InitializeComponent();
            _nfe = nfe;
            nfe.SalvarArquivoXml(_path + @"\tmp.xml");
            webBrowser1.Navigate(_path + @"\tmp.xml");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetornoImpressaoNFe impressao = new ImpressaoNFe()
            { CaminhoSolution = Contexto.CaminhoSolution }.ImprimirNFe(0, _nfe);
            if (impressao.isVisualizar)
                impressao.danfe.Visualizar();
            else
                impressao.danfe.Imprimir(impressao.isCaixaDialogo, impressao.NomeImpressora);
        }
    }
}

using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Util
{
    public static class SituacaoContaUtil
    {
        public static void FormatarLabelSituacao(ref Label label, decimal situacao)
        {
            label.ForeColor = Color.Blue;
            label.Text = "ABERTO";

            if (situacao == StatusConta.Parcial)
            {
                label.ForeColor = Color.Yellow;
                label.Text = "PARCIAL";
                label.BackColor = Color.Gray;
            }

            if (situacao == StatusConta.Baixado)
            {
                label.ForeColor = Color.Green;
                label.Text = "BAIXADO";
            }

            if (situacao == StatusConta.Cancelado)
            {
                label.ForeColor = Color.Red;
                label.Text = "CANCELADO";
            }
        }
    }
}

using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System.Linq;

namespace PDV.VIEW.Forms.Util
{
    public static class PermissoesUtil
    {
        public static void VerificarPermissaoParaTela(decimal[] idsItensMenu, ref SimpleButton button)
        {
            button.Visible = Contexto.ITENSMENU
                .Where(i => idsItensMenu.Contains(i.IDItemMenu))
                .Count() > 0;
        }
    }
}
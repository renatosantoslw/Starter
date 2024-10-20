using ModelAndroidApp.ModelAndroid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndroidApp.Controler
{
    
    public static class VendedorUsuarioController
    {
       
        public static bool SalvarVendedor(Vendedor vendedor)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Vendedor.Add(vendedor);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
          
            return true;
        }
        public static void ExcluirVendedor()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Vendedor");
            }
        }

        public static bool SalvarUsuarioAppEstoque(Usuario usuario)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public static void ExcluirUsuarioEstoque(int IDEmpresa)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Usuario where EmpresaID = "+ IDEmpresa);
            }
        }

    }
}

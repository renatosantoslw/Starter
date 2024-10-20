using ModelAndroidApp.ModelAndroid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndroidApp.Controler
{
    public  static class EmitenteControllerAPP
    {
        public  static bool SalvarEmpresaAPP(Empresa empresa)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Empresa.Add(empresa);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void ExcluirEmresa()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("Delete Empresa");
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }
    }
}

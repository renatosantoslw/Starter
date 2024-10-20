using ModelAndroidApp.ModelAndroid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndroidApp.Controler
{
    public  static class ClienteControllerAPP
    {
        public  static bool SalvarClenteAPP(Cliente cliente)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SalvarDocumentoAPP(Documento ducmento)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Documento.Add(ducmento);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static List<Cliente>ObterClientes()
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    return  db.Cliente.Where(x => x.IDERP == 0).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void ExcluirClientePorID(int ID)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Cliente Where ID =" + ID.ToString());
            }
        }

        public static void ExcluirCliente()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Cliente");
            }
        }
        public static void ExcluirDocumento()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Documento");
            }
        }

        public static void AtualizarBaseCliente(string texto)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand($"Delete BaseAPPs");
                db.Database.ExecuteSqlCommand($"Insert into BaseAPPs  (Clientes)  values(@Clientes) ",new System.Data.SqlClient.SqlParameter("Clientes",texto));
            }
        }
    }
}

using ModelAndroidApp.ModelAndroid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndroidApp.Controler
{
    public  static class NotaControllerAPP
    {
        public  static bool SalvarNotaAPP(Nota nota)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Nota.Add(nota);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SalvarNotaItemAPP(NotaItem notaItem)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.NotaItem.Add(notaItem);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SalvarParcelaAPP(Parcela parcela)
        {
            try
            {
                using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                {
                    db.Parcela.Add(parcela);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void ExcluirNota()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Nota");
               
            }
        }
        public static void ExcluirNotaItem()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete NotaItem");
            }
        }
        public static void ExcluirParcela()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Delete Parcela");
            }
        }
        public static void AtualizarStatusNotaImportado(string ID)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            { 
                db.Database.ExecuteSqlCommand("Update Nota Set Importado = 1 Where ID = " +  ID  );
            }
        }
        public static void AtualizarStatusNotaItemImportado(string ID)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Update NotaItem Set Importado = 1 Where ID = " + ID);
            }
        }
        public static List<Nota> BuscarNota(bool importado)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                List<Nota>lstNota = db.Nota.Where(x=>x.Importado == importado).ToList();
                return lstNota;
            }
        }
        public static List<Nota> BuscarNotaTudo()
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                List<Nota> lstNota = db.Nota.OrderBy(x=>x.Data).ToList();
                return lstNota;
            }
        }
        public static List<NotaItem> BuscarNotaItemPorID(int ID,int IDVendedor)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                List<NotaItem> lstNotaItem = db.NotaItem.Where(x=>x.IDNota==ID && x.IDVendedor == IDVendedor).ToList();
                return lstNotaItem;
            }
        }
        public static List<Parcela> BuscarParcelaPorID(int ID,int IDVendedor)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                List<Parcela> lstParcelaItem = db.Parcela.Where(x=>x.NotaID==ID && x.VendedorID == IDVendedor).ToList();
                return lstParcelaItem;
            }
        }

        public static List<NotaItem> BuscarNotaItem(bool importado)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                List<NotaItem> lstNotaItem = db.NotaItem.Where(x => x.Importado == importado).ToList();
                return lstNotaItem;
            }
        }
        public static List<Parcela> BuscarParcela(bool importado)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                List<Parcela> lstParcelaItem = db.Parcela.Where(x=>x.Importado== importado).ToList();
                return lstParcelaItem;
            }
        }

        public static void AtualizarStatusParcelaImportado(string ID)
        {
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                db.Database.ExecuteSqlCommand("Update Parcela Set Importado = 1 Where ID = " + ID);
            }
        }
    }
}

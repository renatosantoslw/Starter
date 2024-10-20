using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW
{
    class IconesFA
    {


        private static Color _Cor { get; set; }
        private static int _Tamanho { get; set; }

        public IconesFA()
        {
            Bitmap bitmapBuscarProdutoNuvem = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);
    }


        /*  public IconesFA(Color cor,int tamanho)
          {
              _Cor = cor;       
              _Tamanho = tamanho;
          }*/


        public class Icones24
            
            {

            public Bitmap bitmapBuscarProdutoNuvem = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);
        }//public  Bitmap bitmapAcessoRapido = IconChar.Star.ToBitmap(_Cor, _Tamanho);
       




        /* public Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
         public Bitmap bitmapDuplicar = IconChar.Clone.ToBitmap(Color.SteelBlue, 24);
         public Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
         public Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
         public Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 24);
         public Bitmap bitmapMovimento = IconChar.ExchangeAlt.ToBitmap(Color.SteelBlue, 24);
         public Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 24);
         public Bitmap bitmapBuscarProdutoNuvem = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);*/


    }



}

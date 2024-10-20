using System;

namespace PDV.DAO.DB.Utils
{
    public class Criptografia
    {
        private static String vsChaveCrip = "a!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj5";

        public static String DecodificaSenha(String vsSenha)
        {
            if (string.IsNullOrEmpty(vsSenha))
                return String.Empty;

            if (vsSenha.EndsWith("@BI@"))
                vsSenha = vsSenha.Replace("@BI@", " ");

            Byte[] vsSaida = Criptografia.StringToByte(vsSenha);
            Byte[] vbChave = Criptografia.StringToByte(vsChaveCrip);
            Byte[] vbSenhaAux = Criptografia.StringToByte(vsSenha);

            for (int i = 0; i < vbSenhaAux.Length; i++)
            {
                int viCod = vbSenhaAux[i] - ((i >= vbChave.Length) ? 0 : vbChave[i]);
                if ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod + 126;
                }
                while ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod - vbChave[i];
                    if ((viCod > 126) || (viCod < 32))
                    {
                        viCod = viCod + 126;
                    }
                }
                vsSaida[i] = (byte)(viCod);
            }
            return Criptografia.ByteToString(vsSaida);
        }

        public static String CodificaSenha(String vsSenha)
        {
            if (string.IsNullOrEmpty(vsSenha))
                return String.Empty;

            byte[] vbSaida = Criptografia.StringToByte(vsSenha);
            byte[] vbChave = Criptografia.StringToByte(vsChaveCrip);
            byte[] vbChaveAux = Criptografia.StringToByte(vsSenha);
            for (int i = 0; i < vbSaida.Length; i++)
            {
                int viCod = vbSaida[i] + ((i >= vbChave.Length) ? 0 : vbChave[i]);
                if ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod - 126;
                }
                while ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod + vbChave[i];
                    if ((viCod > 126) || (viCod < 32))
                    {
                        viCod = viCod - 126;
                    }
                }
                vbChaveAux[i] = (byte)(viCod);
            }
            string vsRetorno = Criptografia.ByteToString(vbChaveAux);
            return vsRetorno;
        }

        public static byte[] StringToByte(string InString)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(InString);
        }

        public static string ByteToString(byte[] Bytes)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(Bytes);
        }
    }
}

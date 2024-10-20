namespace IntegradorZeusPDV.DB.DB.CriptografiaMD5
{
    public class CriptografiaMD5
    {
        public static string CodificaSenha(string Chave, string Senha)
        {
            DemoEncryption Demo = new DemoEncryption(Chave);
            return Demo.EncryptUsernamePassword(Senha);
        }

        public static string DecodificaSenha(string Chave, string Senha)
        {
            DemoEncryption Demo = new DemoEncryption(Chave);
            return Demo.DecryptUsernamePassword(Senha);
        }
    }
}

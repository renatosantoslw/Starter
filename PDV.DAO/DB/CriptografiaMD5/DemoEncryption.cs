using System.Security.Cryptography;
using System.Text;

namespace PDV.DAO.DB.CriptografiaMD5
{
    public class DemoEncryption
    {
        private const int IterationsMd5 = 19;
        private string Password { get; set; }

        public DemoEncryption(string Password)
        {
            this.Password = Password;
        }

        /// <summary>
        /// Use this method to encrypt usernames and passwords in the Demo user table.  The password and salt are hardcoded into this method.
        /// </summary>
        /// <param name="clearText">This is the clear text you wish to encrypt.</param>
        /// <returns>Returns the encrypted version of the clear text.</returns>
        public string EncryptUsernamePassword(string clearText)
        {
            // TODO: Parameterize the Password, Salt, and Iterations.  They should be encrypted with the machine key and stored in the registry

            if (string.IsNullOrEmpty(clearText))
            {
                return clearText;
            }

            byte[] salt = new byte[]
            {
                (byte)0xA9, (byte)0x9B, (byte)0xC8, (byte)0x32,
                (byte)0x56, (byte)0x34, (byte)0xE3, (byte)0x03
            };

            // NOTE: The keystring, salt, and iterations must be the same as what is used in the Demo java system.
            PKCSKeyGenerator crypto = new PKCSKeyGenerator(this.Password, salt, IterationsMd5, 1);

            ICryptoTransform cryptoTransform = crypto.Encryptor;
            byte[] cipherBytes = cryptoTransform.TransformFinalBlock(Encoding.UTF8.GetBytes(clearText), 0, clearText.Length);
            return System.Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// Use this method to decrypt usernames and passwords in the Demo user table.  The password and salt are hardcoded into this method.
        /// </summary>
        /// <param name="clearText">This is the cipher text you wish to decrypt.</param>
        /// <returns>Returns the decrypted version of the cipher text.</returns>
        public string DecryptUsernamePassword(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return cipherText;
            }

            byte[] salt = new byte[]
            {
                (byte)0xA9, (byte)0x9B, (byte)0xC8, (byte)0x32,
                (byte)0x56, (byte)0x34, (byte)0xE3, (byte)0x03
            };

            // NOTE: The keystring, salt, and iterations must be the same as what is used in the Demo java system.
            PKCSKeyGenerator crypto = new PKCSKeyGenerator(this.Password, salt, IterationsMd5, 1);

            ICryptoTransform cryptoTransform = crypto.Decryptor;
            byte[] cipherBytes = System.Convert.FromBase64String(cipherText);
            byte[] clearBytes = cryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(clearBytes);
        }
    }
}

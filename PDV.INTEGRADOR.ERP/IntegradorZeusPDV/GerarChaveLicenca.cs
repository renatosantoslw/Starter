using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using System.IO;

namespace IntegradorDUEPDV
{
    public class GerarChaveLicenca
    {
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        public static string EncryptMessage(String message)
        {
            // Initialize the certificate
            X509Certificate2 cert = new X509Certificate2();
            //create string encoder
            UTF8Encoding encoder = new UTF8Encoding();
            // import certificate
            X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.DefaultKeySet;
            //Create X509Certificate2 object from .cer file.
            byte[] rawData = ReadFile(@"c:\Certificados\ELETRONICOSLUAR.pfx");
            cert.Import(@"c:\Certificados\ELETRONICOSLUAR.pfx","1234", keyStorageFlags);

            ContentInfo contentInfo = new ContentInfo(encoder.GetBytes(message));
            EnvelopedCms envelop = new EnvelopedCms(contentInfo);
            CmsRecipient recip = new CmsRecipient(cert);
            envelop.Encrypt(recip);
            byte[] encoded = envelop.Encode();
            return Convert.ToBase64String(envelop.Encode());
        }

        // Decrypt 
        public static string DecryptMessage(string message)
        {
            UTF8Encoding encoder = new UTF8Encoding();

            EnvelopedCms envelop = new EnvelopedCms();
            envelop.Decode(Convert.FromBase64String(message));
            //envelop.Decrypt(envelop.RecipientInfos[0]);
            envelop.Decrypt();

            byte[] messageInBytes = envelop.ContentInfo.Content;

            return encoder.GetString(messageInBytes);
        }
        internal static byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }
        public static void CreateTrailfunctionality()
        {
            try
            {
                Microsoft.Win32.RegistryKey EncryptedKey;
                RSACryptoServiceProvider crypto = new RSACryptoServiceProvider();
                EncryptedKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\EncryptedDateww");

                object value = EncryptedKey.GetValue("EncryptedDateww");

                if (value == null)
                {
                    EncryptedKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\EncryptedDateww");

                    string keyvalue = DateTime.Now.AddDays(45).ToString("dd-MMM-yyyy") + "12069715000180" + "0002" + "decode";
                    byte[] messageBytes = Encoding.Unicode.GetBytes(keyvalue);



                    string encryptedMessage = Encrypt(keyvalue); //EncryptMessage(keyvalue);//Convert.ToBase64String(messageBytes);

                    EncryptedKey.SetValue("EncryptedDateww", encryptedMessage);
                }
                else
                {
                    string encryptedMessage = Decrypt(value.ToString()); //DecryptMessage(value.ToString());
                    byte[] encryptedMessage1 = Convert.FromBase64String(value.ToString());

                    string key = System.Text.Encoding.Unicode.GetString(encryptedMessage1);

                    DateTime date = Convert.ToDateTime(key);

                    string sAux =  date.ToString("dd-MMM-yyyy");
                }

            }
            catch (Exception e)
            { }
        }
    }
}



//using System;
//using System.Security.Cryptography;
//using System.Security.Permissions;
//using System.IO;
//using System.Security.Cryptography.X509Certificates;


//class CertInfo
//{
//    //Reads a file.
//    internal static byte[] ReadFile(string fileName)
//    {
//        FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
//        int size = (int)f.Length;
//        byte[] data = new byte[size];
//        size = f.Read(data, 0, size);
//        f.Close();
//        return data;
//    }
//    //Main method begins here.
//    static void Main(string[] args)
//    {
//        //Test for correct number of arguments.
//        if (args.Length < 1)
//        {
//            Console.WriteLine("Usage: CertInfo <filename>");
//            return;
//        }
//        try
//        {
//            X509Certificate2 x509 = new X509Certificate2();
//            //Create X509Certificate2 object from .cer file.
//            byte[] rawData = ReadFile(args[0]);

//            x509.Import(rawData);

//            //Print to console information contained in the certificate.
//            Console.WriteLine("{0}Subject: {1}{0}", Environment.NewLine, x509.Subject);
//            Console.WriteLine("{0}Issuer: {1}{0}", Environment.NewLine, x509.Issuer);
//            Console.WriteLine("{0}Version: {1}{0}", Environment.NewLine, x509.Version);
//            Console.WriteLine("{0}Valid Date: {1}{0}", Environment.NewLine, x509.NotBefore);
//            Console.WriteLine("{0}Expiry Date: {1}{0}", Environment.NewLine, x509.NotAfter);
//            Console.WriteLine("{0}Thumbprint: {1}{0}", Environment.NewLine, x509.Thumbprint);
//            Console.WriteLine("{0}Serial Number: {1}{0}", Environment.NewLine, x509.SerialNumber);
//            Console.WriteLine("{0}Friendly Name: {1}{0}", Environment.NewLine, x509.PublicKey.Oid.FriendlyName);
//            Console.WriteLine("{0}Public Key Format: {1}{0}", Environment.NewLine, x509.PublicKey.EncodedKeyValue.Format(true));
//            Console.WriteLine("{0}Raw Data Length: {1}{0}", Environment.NewLine, x509.RawData.Length);
//            Console.WriteLine("{0}Certificate to string: {1}{0}", Environment.NewLine, x509.ToString(true));

//            Console.WriteLine("{0}Certificate to XML String: {1}{0}", Environment.NewLine, x509.PublicKey.Key.ToXmlString(false));

//            //Add the certificate to a X509Store.
//            X509Store store = new X509Store();
//            store.Open(OpenFlags.MaxAllowed);
//            store.Add(x509);
//            store.Close();
//        }

//        catch (DirectoryNotFoundException)
//        {
//            Console.WriteLine("Error: The directory specified could not be found.");
//        }
//        catch (IOException)
//        {
//            Console.WriteLine("Error: A file in the directory could not be accessed.");
//        }
//        catch (NullReferenceException)
//        {
//            Console.WriteLine("File must be a .cer file. Program does not have access to that type of file.");
//        }
//    }

//}
using Proiect_C_.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_C_.Encryption
{
    internal class EncryptionUtils
    {
        private static readonly byte[] salt = Encoding.ASCII.GetBytes(Settings.Default.Salt);
        internal static string DecryptString(string cipherText, string password)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using (var aes = Aes.Create())
            {
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA512);
                aes.Key = pbkdf2.GetBytes(32);
                aes.IV = pbkdf2.GetBytes(16);

                using (var decryptor = aes.CreateDecryptor())
                {
                    using (var memoryStream = new MemoryStream(cipherTextBytes))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
        }
        internal static string EncryptString(string text, string password)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);

            using (var aes = Aes.Create())
            {
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA512);
                aes.Key = pbkdf2.GetBytes(32);
                aes.IV = pbkdf2.GetBytes(16);

                using (var encryptor = aes.CreateEncryptor())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();

                            byte[] cipherTextBytes = memoryStream.ToArray();

                            return Convert.ToBase64String(cipherTextBytes);
                        }
                    }
                }
            }
        }
    }
}

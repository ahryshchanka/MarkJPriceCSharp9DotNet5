using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MarkJPriceCSharp9DotNet5.Ch10
{
    static class Program
    {
        private static readonly int Iterations = 2000;
        private static readonly byte[] Salt = GetSalt();

        static void Main()
        {
            var str = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var encrypted = Encrypt(str, "12345");
            var decrypted = Decrypt(encrypted, "12345");

            Console.WriteLine(encrypted);
            Console.WriteLine("------------------");
            Console.WriteLine(decrypted);
        }

        private static byte[] GetSalt(int maxLength = 32)
        {
            var result = new byte[12];
            using RNGCryptoServiceProvider random = new();
            random.GetNonZeroBytes(result);

            return result;
        }

        private static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, Salt, Iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plainBytes, 0, plainBytes.Length);
            encryptedBytes = ms.ToArray();
            return Convert.ToBase64String(encryptedBytes);
        }

        private static string Decrypt(string cryptoText, string password)
        {
            using var aes = Aes.Create();

            using var pbkdf2 = new Rfc2898DeriveBytes(password, Salt, Iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            cs.Write(cryptoBytes, 0, cryptoBytes.Length);
            byte[] plainBytes = ms.ToArray();

            return Encoding.Unicode.GetString(plainBytes);
        }
    }
}
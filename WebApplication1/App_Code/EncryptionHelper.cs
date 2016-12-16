using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.App_Code
{
    public static class EncryptionHelper
    {
        public static async Task<string> Encrypt1(string data, string key)
        {
            try
            {
                var provider = new AesCryptoServiceProvider();
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.GenerateIV();

                var encryptor = provider.CreateEncryptor(provider.Key, provider.IV);
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                var writer = new StreamWriter(cryptoStream);
                await writer.WriteAsync(data);
                var encrypted = memoryStream.ToArray();
                byte[] all = new byte[provider.IV.Length + encrypted.Length];
                Buffer.BlockCopy(provider.IV, 0, all, 0, provider.IV.Length);
                Buffer.BlockCopy(encrypted, 0, all, provider.IV.Length, encrypted.Length);

                return Convert.ToBase64String(all);

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static async Task<string> Decrypt2(string data,string key)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                if (bytes.Length <= 16)
                {
                    return null;
                }

                var iv = new byte[16];
                var encrypted = new byte[bytes.Length - iv.Length];
                Buffer.BlockCopy(bytes, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(bytes, iv.Length, encrypted, 0, encrypted.Length);

                var provider = new AesCryptoServiceProvider();
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.IV = iv;

                var decryptor = provider.CreateDecryptor(provider.Key, provider.IV);
                var memoryStream = new MemoryStream(encrypted);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                var reader = new StreamReader(cryptoStream);

                return await reader.ReadToEndAsync();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public static string Encrypt(string data, string key)
        {
            try
            {
                var provider = new AesCryptoServiceProvider();
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.GenerateIV();

                var encryptor = provider.CreateEncryptor(provider.Key, provider.IV);
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                var writer = new StreamWriter(cryptoStream);
                writer.Write(data);
                var encrypted = memoryStream.ToArray();
                byte[] all = new byte[provider.IV.Length + encrypted.Length];
                Buffer.BlockCopy(provider.IV, 0, all, 0, provider.IV.Length);
                Buffer.BlockCopy(encrypted, 0, all, provider.IV.Length, encrypted.Length);

                return Convert.ToBase64String(all);

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string data, string key)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                if (bytes.Length <= 16)
                {
                    return null;
                }

                var iv = new byte[16];
                var encrypted = new byte[bytes.Length - iv.Length];
                Buffer.BlockCopy(bytes, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(bytes, iv.Length, encrypted, 0, encrypted.Length);

                var provider = new AesCryptoServiceProvider();
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.IV = iv;

                var decryptor = provider.CreateDecryptor(provider.Key, provider.IV);
                var memoryStream = new MemoryStream(encrypted);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                var reader = new StreamReader(cryptoStream);

                return reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
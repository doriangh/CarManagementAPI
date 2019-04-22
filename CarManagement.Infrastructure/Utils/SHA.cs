using System;
using System.Security.Cryptography;
using System.Text;

namespace CarManagement.Infrastructure.Utils
{
    public static class Sha
    {
        public static string ComputeSha(string str)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                
                var stringBuilder = new StringBuilder();

                for (var i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static string Encrypt(string str)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var utf8Encoding = new UTF8Encoding();
                var data = md5.ComputeHash(utf8Encoding.GetBytes(str));
                return Convert.ToBase64String(data);
            }
        }
    }
}
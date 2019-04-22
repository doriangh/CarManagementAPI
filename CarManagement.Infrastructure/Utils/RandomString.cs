using System;

namespace CarManagement.Infrastructure.Utils
{
    public class RandomString
    {
        private static readonly Random Random = new Random();

        public static string CreateString(int length)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[Random.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
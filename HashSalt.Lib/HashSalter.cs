using System;
using System.Text;
using System.Security.Cryptography;
using BCrypt.Net;

namespace HashSalt.Lib
{
    public static class HashSalter
    {
        // SHA256
        public static string GetSalt(int size) {
            RNGCryptoServiceProvider rng = new();
            byte[] buffer = new byte[size];

            // Fill buffer with random sequence of values
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public static string GetHash(string input, string salt) {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed shaString = new();
            byte[] hash = shaString.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public static bool ConfirmHash(string text, string hashed, string salt) {
            string newHashPin = GetHash(text, salt);

            return newHashPin.Equals(hashed);
        }

        // BCRYPT
        public static string GetBHash(string input) {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }

        public static bool ConfirmBHash(string input, string pw) {
            return BCrypt.Net.BCrypt.Verify(input, pw);
        }

    }
}

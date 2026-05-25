using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PhoneBook
{
    public static class PasswordManager
    {
        private static readonly string HashFilePath = "pwd.dat";

        // Вызывается один раз при первом запуске программы для создания пароля
        public static void SavePassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                File.WriteAllBytes(HashFilePath, hashBytes);
            }
        }

        // Проверка введенного пользователем пароля
        public static bool VerifyPassword(string inputPassword)
        {
            if (!File.Exists(HashFilePath)) return false;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                byte[] savedHash = File.ReadAllBytes(HashFilePath);

                if (inputHash.Length != savedHash.Length) return false;
                for (int i = 0; i < inputHash.Length; i++)
                {
                    if (inputHash[i] != savedHash[i]) return false;
                }
                return true;
            }
        }
    }
}

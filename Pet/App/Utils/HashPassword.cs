
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Pet.App.Utils
{
    public class HashPassword
    {
        public Values HashPasswd (string password)
        {
            var saltBytes = GenerateSalt();

            // Hash com SHA256
            var hashBytes = EncodePasswdSalt(CombinatePasswdAndSalt(password, saltBytes));

            // Converter o hash e o salt para uma representação base64
            string hashString = Convert.ToBase64String(hashBytes);
            string saltString = Convert.ToBase64String(saltBytes);

            // Retornar o hash e salt encapsulado na classe values
            return new Values { Hash = hashString, Salt = saltString };
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            // Converter o salt armazenado de volta para bytes
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            // Combinar a senha inserida e o salt armazenado
            byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];

            Buffer.BlockCopy(saltBytes, 0, passwordWithSaltBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSaltBytes, saltBytes.Length, passwordBytes.Length);

            // Hash com SHA256
            byte[] hashBytes;
            using (var sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordWithSaltBytes);
            }

            // Converter o hash para uma string base64 e comparar com o hash armazenado
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString == storedHash;
        }
        public class Values
        {
            public required string Hash { get; set; }
            public required string Salt { get; set; }
        }

        private static byte[] GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            RandomNumberGenerator.Fill(saltBytes);
            return saltBytes;
        }

        private static byte[] CombinatePasswdAndSalt(string password, byte[] saltBytes)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];

            Buffer.BlockCopy(saltBytes, 0, passwordWithSaltBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSaltBytes, saltBytes.Length, passwordBytes.Length);

            return passwordBytes;
        }

        private static byte[] EncodePasswdSalt(byte[]  passwordWithSaltBytes)
        {
            byte[] hashBytes;
            using (var sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordWithSaltBytes);
            }
            return hashBytes;
        }
    }
}

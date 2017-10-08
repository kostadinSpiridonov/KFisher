using System;
using System.Security.Cryptography;
using System.Text;

namespace KFishers.Managers.Security
{
    public class HashGenerator : IHashGenerator
    {
        private readonly string salt = "#k?@prop^&";

        private SHA512Managed shaLibrary;

        public HashGenerator()
        {
            this.shaLibrary = new SHA512Managed();
        }

        public string ComputeSHA512Hash(string value)
        {
            string combinedPassword = String.Concat(value, this.salt);
            var bytes = Encoding.UTF8.GetBytes(combinedPassword);
            var hash = shaLibrary.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public bool VerifySHA512Hash(string hash, string value)
        {
            return hash == this.ComputeSHA512Hash(value);
        }
    }
}

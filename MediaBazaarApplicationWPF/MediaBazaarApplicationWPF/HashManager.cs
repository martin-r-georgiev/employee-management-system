using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MediaBazaarApplicationWPF
{
    class HashManager
    {
        public static string GetSha256(string inputString)
        {
            StringBuilder hash = new System.Text.StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                foreach (byte b in bytes) { hash.Append(b.ToString("x2")); }
            }
            return hash.ToString();
        }
    }
}

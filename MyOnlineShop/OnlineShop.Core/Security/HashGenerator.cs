using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Security
{
    public class HashGenerator
    {
        private static string Generate(string plaintext, string hashType)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(plaintext);
            byte[] hashed = HashAlgorithm.Create(hashType).ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }

        public static string Salterhash(string plaintext)
        {
            // var test= Enum.GetName(typeof(HashType), HashType.MD5);
            //float cofficient = (2 / 3);
            return Generate(plaintext, nameof(HashType.MD5)) + Generate(plaintext.Substring(0, plaintext.Length / 2), nameof(HashType.SHA1));
        }
    }
}

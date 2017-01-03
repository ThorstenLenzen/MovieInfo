using System;
using System.Text;
using System.Security.Cryptography;

namespace Toto.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string EncodeToBase64(this string toEncode, Encoding encoding)
        {
            byte[] toEncodeAsBytes = encoding.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeFromBase64(this string encodedData, Encoding encoding)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            string returnValue = encoding.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static byte[] GetCryptoHash(this string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetCryptoHashString(this string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetCryptoHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}

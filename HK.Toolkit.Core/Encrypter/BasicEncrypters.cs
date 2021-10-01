using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HK.Toolkit.Encrypter
{
    public static class BasicEncrypters
    {
        /// <summary>
        /// It gets  a plain text and code like this"&%#@?,:&" and EncRypt The Text using that key
        /// </summary>
        /// <param name="plainText">Plain Text</param>
        /// <param name="privateKey">Pass smth like "&%#@?,:&"</param>
        /// <returns>String</returns>
        public static string Encrypt(this string plainText, string privateKey = "&%#@?,:&")
        {
            byte[] iv = { 18, 52, 86, 120, 144, 171, 205, 239 };

            try
            {
                var byKey = Encoding.UTF8.GetBytes(privateKey.Substring(0, 8));
                var des = new DESCryptoServiceProvider();
                var inputByteArray = Encoding.UTF8.GetBytes(plainText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, iv), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception)
            {
                return plainText;
            }
        }

        /// <summary>
        /// It gets  a plain text and code like this"&%#@?,:&" and DecRypt The Text using that key
        /// </summary>
        /// <param name="plainText">Plain Text</param>
        /// <param name="privateKey">Pass smth like "&%#@?,:&"</param>
        /// <returns>String</returns>
        public static string Decrypt(this string plainText, string privateKey = "&%#@?,:&")
        {
            byte[] iv = { 18, 52, 86, 120, 144, 171, 205, 239 };

            try
            {
                var byKey = Encoding.UTF8.GetBytes(privateKey.Substring(0, 8));
                var des = new DESCryptoServiceProvider();
                var inputByteArray = Convert.FromBase64String(plainText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return plainText;
            }
        }
    }
}
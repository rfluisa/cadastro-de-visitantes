using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeVisitantes.Core
{
    public static class Criptografia
    {
        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="password">Password</param>
        public static string Criptografar(string password)
        {

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            //var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            //var bytesEncrypted = Cipher.Encrypt(bytesToBeEncrypted, passwordBytes);
            using (SHA512 shaM = new SHA512Managed())
            {
                var hash = shaM.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hash);
            }
        }

        ///// <summary>
        ///// Decrypt a string.
        ///// </summary>
        ///// <param name="encryptedText">String to be decrypted</param>
        ///// <param name="password">Password used during encryption</param>
        ///// <exception cref="FormatException"></exception>
        //public static string Decrypt(string encryptedText, string password)
        //{
        //    if (encryptedText == null)
        //    {
        //        return null;
        //    }

        //    if (password == null)
        //    {
        //        password = String.Empty;
        //    }

        //    // Get the bytes of the string
        //    var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
        //    var passwordBytes = Encoding.UTF8.GetBytes(password);

        //    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

        //    //var bytesDecrypted = Cipher.Decrypt(bytesToBeDecrypted, passwordBytes);

        //    return Encoding.UTF8.GetString(bytesDecrypted);
        //}

    }
}

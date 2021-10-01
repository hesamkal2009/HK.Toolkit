using System;
using System.Security.Cryptography;

namespace HK.Toolkit.Hashers
{
    public static class IdentityHasher
    {

        // 24 = 192 bits
        private const int SaltByteSize = 24;

        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;

        /// <summary>
        /// Hash a plain password using asp.net Identity password hashing method
        /// </summary>
        /// <param name="password">plain password</param>
        /// <returns>hashed password</returns>
        public static string HashPassword(this string password)
        {
            // http://stackoverflow.com/questions/19957176/asp-net-identity-password-hashing

            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SaltByteSize, HasingIterationsCount))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(HashByteSize);
            }
            byte[] dst = new byte[(SaltByteSize + HashByteSize) + 1];
            Buffer.BlockCopy(salt, 0, dst, 1, SaltByteSize);
            Buffer.BlockCopy(buffer2, 0, dst, SaltByteSize + 1, HashByteSize);
            return Convert.ToBase64String(dst);
        }

        /// <summary>
        /// Verfies a passwrod that hashed using asp.net Identity method
        /// </summary>
        /// <param name="hashedPassword">Hashed Password</param>
        /// <param name="password">Plain Password</param>
        /// <returns>Returns Boolean</returns>
        public static bool IsHashedPasswordEqual(this string hashedPassword, string password)
        {
            byte[] passwordHashBytes;

            int _arrayLen = (SaltByteSize + HashByteSize) + 1;

            if (hashedPassword == null)
            {
                return false;
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] src = Convert.FromBase64String(hashedPassword);

            if ((src.Length != _arrayLen) || (src[0] != 0))
            {
                return false;
            }

            byte[] currentSaltBytes = new byte[SaltByteSize];
            Buffer.BlockCopy(src, 1, currentSaltBytes, 0, SaltByteSize);

            byte[] currentHashBytes = new byte[HashByteSize];
            Buffer.BlockCopy(src, SaltByteSize + 1, currentHashBytes, 0, HashByteSize);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, currentSaltBytes, HasingIterationsCount))
            {
                passwordHashBytes = bytes.GetBytes(SaltByteSize);
            }

            return AreHashesEquals(currentHashBytes, passwordHashBytes);

            static bool AreHashesEquals(byte[] firstHash, byte[] secondHash)
            {
                int minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
                var xor = firstHash.Length ^ secondHash.Length;
                for (int i = 0; i < minHashLength; i++)
                    xor |= firstHash[i] ^ secondHash[i];
                return 0 == xor;
            }
        }
    }
}


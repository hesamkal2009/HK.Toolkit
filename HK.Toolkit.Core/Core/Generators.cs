using System;

namespace HK.Toolkit.Core
{
    public static class Generators
    {
        /// <summary>
        /// Generate a Verification Code with 4 digit
        /// </summary>
        /// <returns>returns String </returns>
        public static string GenerateFourDigitCode()
        {
            try
            {
                var random = new Random();
                var verificationNumber = random.Next(1000, 9999).ToString();
                return verificationNumber;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Generate a Verification Code with 5 digit
        /// </summary>
        /// <returns>returns String </returns>
        public static string GenerateFiveDigitCode()
        {
            try
            {
                var random = new Random();
                var verificationNumber = random.Next(10000, 99999).ToString();
                return verificationNumber;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Generate a Verification Code with 6 digit
        /// </summary>
        /// <returns>returns String </returns>
        public static string GenerateSixDigitCode()
        {
            try
            {
                var random = new Random();
                var verificationNumber = random.Next(100000, 999999).ToString();
                return verificationNumber;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
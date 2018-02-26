using System;

namespace Task1Logic
{
    /// <summary>
    /// Extension class for Customer for getting new format method
    /// </summary>
    public static class CustomerHelper
    {
        #region Public Method

        /// <summary>
        /// Extension format method
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="preString"></param>
        /// <returns></returns>
        public static string ToString(this Customer customer, string format = "f",
            IFormatProvider provider = null, string preString = "")
        {
            CheckArguments(ref format, provider);
            return GetFormatedStringValue(customer, format, preString);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check arguments
        /// </summary>
        /// <param name="format">Format for result string</param>
        /// <param name="provider">Culture for specific format</param>
        private static void CheckArguments(ref string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "f";
            }
        }

        /// <summary>
        /// Return string by format
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="format">Format for result string</param>
        /// <param name="preString">Sentese for starting result string line</param>
        /// <returns>String line</returns>
        private static string GetFormatedStringValue(Customer customer, string format, string preString)
        {
            switch (format)
            {
                case "f": return $"{preString} {customer.Name}, {customer.Revenue.ToString("N")}, {customer.ContactPhone}";
                default:
                    throw new FormatException("Unknown format: " + format);
            }
        }

        #endregion
    }
}

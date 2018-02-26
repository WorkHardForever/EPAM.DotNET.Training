using System;

namespace Task1Logic
{
    /// <summary>
    /// Simple customer with Name, Revenue and ContactPhone properties
    /// </summary>
    public class Customer : IFormattable
    {
        #region Public Properties

        /// <summary>
        /// Customer's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Customer's revenue
        /// </summary>
        public decimal Revenue { get; private set; }

        /// <summary>
        /// Customer's contact phone
        /// </summary>
        public string ContactPhone { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Set fields in constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="revenue"></param>
        /// <param name="contactPhone"></param>
        public Customer(string name = null, decimal revenue = 0, string contactPhone = null)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = contactPhone;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Implementation ToString of IFormattable
        /// </summary>
        /// <param name="format">Format for result string</param>
        /// <param name="provider">Culture for specific format</param>
        /// <returns>String line</returns>
        public string ToString(string format = "f", IFormatProvider provider = null)
        {
            CheckArguments(ref format, provider);
            return GetFormatedStringValue(format);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check arguments
        /// </summary>
        /// <param name="format">Format for result string</param>
        /// <param name="provider">Culture for specific format</param>
        private void CheckArguments(ref string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "f";
            }
        }

        /// <summary>
        /// Return string by format
        /// </summary>
        /// <param name="format">Format for result string</param>
        /// <returns>String line</returns>
        private string GetFormatedStringValue(string format)
        {
            var stringValue = "Customer record:";
            switch (format)
            {
                case "f":  return $"{stringValue} {Name}, {Revenue.ToString("N")}, {ContactPhone}";
                case "c":  return $"{stringValue} {ContactPhone}";
                case "nr": return $"{stringValue} {Name}, {Revenue.ToString("N")}";
                case "n":  return $"{stringValue} {Name}";
                case "r-": return $"{stringValue} {Revenue}";
                case "r":  return $"{stringValue} {Revenue.ToString("N")}";
                case "sf": return $"{GetType()} -> {Name}, {Revenue.ToString("N")}, {ContactPhone}";
                default:
                    throw new FormatException("Unknown format: " + format);
            }
        }

        #endregion
    }
}

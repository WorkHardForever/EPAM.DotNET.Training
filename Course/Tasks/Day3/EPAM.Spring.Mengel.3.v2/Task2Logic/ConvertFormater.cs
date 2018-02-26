using System;
using System.Globalization;

namespace Task2Logic
{
    /// <summary>
    /// Class for using convert operations in formatting
    /// </summary>
    public class ConvertFormatter : IFormattable
    {
        #region Property

        /// <summary>
        /// Value to convert
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region Public Method

        /// <summary>
        /// Implementation ToString of IFormattable
        /// </summary>
        /// <param name="format">Format for result string</param>
        /// <param name="provider">Culture for specific format</param>
        /// <returns>String line</returns>
        public string ToString(string format = "n", IFormatProvider provider = null)
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
                format = "n";
            }
        }

        /// <summary>
        /// Return string by format
        /// </summary>
        /// <param name="format">Format for result string</param>
        /// <returns>String line</returns>
        private string GetFormatedStringValue(string format)
        {
            var convertType = ChooseType(format);
            if (convertType == ConvertType.None)
                return Value.ToString();

            var result = ChangeByFormat(convertType);

            if (result == null)
                return CheckOtherFormats(format);
            return result;
        }

        /// <summary>
        /// Get type of changing by format
        /// </summary>
        /// <param name="format">Literals for changing</param>
        /// <returns>Type of converting</returns>
        private ConvertType ChooseType(string format)
        {
            switch (format)
            {
                case "n": return ConvertType.None;
                case "h": return ConvertType.Hex;
                default:
                    throw new FormatException("Unknown format: " + format);
            }
        }

        /// <summary>
        /// Parse args throw there types
        /// </summary>
        /// <param name="convertType">Type of converting</param>
        /// <returns>String by converting</returns>
        private string ChangeByFormat(ConvertType convertType)
        {
            if (Value is byte) return ConvertHelper.ConvertTo((byte)Value, convertType);
            if (Value is ushort) return ConvertHelper.ConvertTo((ushort)Value, convertType);
            if (Value is uint) return ConvertHelper.ConvertTo((uint)Value, convertType);
            if (Value is ulong) return ConvertHelper.ConvertTo((ulong)Value, convertType);
            if (Value is sbyte) return ConvertHelper.ConvertTo((sbyte)Value, convertType);
            if (Value is short) return ConvertHelper.ConvertTo((short)Value, convertType);
            if (Value is int) return ConvertHelper.ConvertTo((int)Value, convertType);
            if (Value is long) return ConvertHelper.ConvertTo((long)Value, convertType);
            else return null;
        }

        /// <summary>
        /// Find other formats if target argument or format not found
        /// </summary>
        /// <param name="format">Literals for changing</param>
        /// <returns>String by converting</returns>
        private string CheckOtherFormats(string format)
        {
            try
            {
                return HandleOtherFormats(format);
            }
            catch (FormatException e)
            {
                throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
            }
        }

        /// <summary>
        /// Try to find other format output
        /// </summary>
        /// <param name="format">Literals for changing</param>
        /// <returns>String by such format</returns>
        private string HandleOtherFormats(string format) =>
            Value is IFormattable ? ((IFormattable)Value).ToString(format, CultureInfo.CurrentCulture) :
            Value != null ? Value.ToString() :
            string.Empty;

        #endregion
    }
}

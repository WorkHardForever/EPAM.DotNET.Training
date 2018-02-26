namespace Task2Logic
{
    /// <summary>
    /// Help to convert to convert type
    /// </summary>
    public static class ConvertHelper
    {
        #region Private Field

        /// <summary>
        /// Numeric alphabet
        /// </summary>
        private static readonly char[] numericSymbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        #endregion

        #region Public Methods

        /// <summary>
        /// Convert all integer signed number
        /// </summary>
        /// <param name="number">Number for converting</param>
        /// <param name="type">Type of converting</param>
        /// <returns>Result of converting</returns>
        public static string ConvertTo(long number, ConvertType type)
        {
            var isNegative = number < 0 ? true : false;
            if (isNegative)
                number *= -1;

            var convertedNumber = GetConvertValue((ulong)number, type);

            if (isNegative)
                convertedNumber = "-" + convertedNumber;

            return convertedNumber;
        }

        /// <summary>
        /// Convert all integer unsigned number
        /// </summary>
        /// <param name="number">Number for converting</param>
        /// <param name="type">Type of converting</param>
        /// <returns>Result of converting</returns>
        public static string ConvertTo(ulong number, ConvertType type) =>
            GetConvertValue(number, type);

        #endregion

        #region Private Method

        /// <summary>
        /// Convert long integer number to a type of converting
        /// </summary>
        /// <param name="number">Number for converting</param>
        /// <param name="type">Type of converting</param>
        /// <returns>Result of converting</returns>
        private static string GetConvertValue(ulong number, ConvertType type)
        {
            var convertedNumber = string.Empty;
            while (true)
            {
                convertedNumber = numericSymbols[number % (uint)type] + convertedNumber;
                number /= (uint)type;

                if (number == 0)
                    break;
            }

            return convertedNumber;
        }

        #endregion
    }
}

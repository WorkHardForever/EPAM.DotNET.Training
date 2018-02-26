using System;
using static System.Text.RegularExpressions.Regex;
using Task3Logic;

namespace Task4Logic
{
    public class ConcatStrings
    {
        public string SortByAlphabetWithoutRepeated(string strA, string strB)
        {
            if (strA == null)
            {
                throw new ArgumentNullException(nameof(strA));
            }

            if (strB == null)
            {
                throw new ArgumentNullException(nameof(strB));
            }

            if (IsMatch(strA, @"\d"))
            {
                throw new ArgumentException($"Argument {nameof(strA)} should be only with symbols 'a'-'z'");
            }

            if (IsMatch(strB, @"\d"))
            {
                throw new ArgumentException($"Argument {nameof(strB)} should be only with symbols 'a'-'z'");
            }

            return new string((strA + strB).ToCharArray().SortToUnrepeatedItems());
        }
    }
}

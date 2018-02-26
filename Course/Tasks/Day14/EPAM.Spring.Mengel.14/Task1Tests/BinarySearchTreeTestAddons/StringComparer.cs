using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Tests.BinarySearchTreeTestAddons
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y) =>
            x[0].CompareTo(y[0]);
    }
}

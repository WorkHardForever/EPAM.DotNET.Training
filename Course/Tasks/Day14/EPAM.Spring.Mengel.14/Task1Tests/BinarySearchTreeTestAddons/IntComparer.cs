using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Tests.BinarySearchTreeTestAddons
{
    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var modX = x % 2;
            var modY = y % 2;

            if (modX == modY)
                return 0;
            else if (modX > modY)
                return 1;
            else
                return -1;
        }
    }
}

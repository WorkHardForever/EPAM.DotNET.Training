using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public static class Sort2
    {
        public static void Sort(int[] a)
        {
            quickSort(a, 0, a.Length - 1);
        }
        private static void quickSort(int[] a, int l, int r)
        {
            int temp;
            int x = a[l + (r - l) / 2]; int i = l; int j = r;
            while (i <= j)
            {
                while (a[i].CompareTo(x) < 0) i++;
                while (a[j].CompareTo(x) > 0) j--;
                if (i <= j)
                {
                    temp = a[i]; a[i] = a[j];
                    a[j] = temp; i++; j--;
                }
            }
            if (i < r) quickSort(a, i, r);

            if (l < j) quickSort(a, l, j);
        }
    }
}





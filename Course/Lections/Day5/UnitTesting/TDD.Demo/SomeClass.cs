using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Demo
{
    public class SomeClass
    {
        public static int SomeMethod(int[] a)
        {
            if (a == null) throw new ArgumentNullException("a");

            int sum = 0;

            checked
            {
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                
            }
                
           
            return sum;
        }
    }
}

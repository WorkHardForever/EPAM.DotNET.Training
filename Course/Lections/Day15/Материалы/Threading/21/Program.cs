using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            for (int j = 0; j < int.MaxValue; j++)
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    a = a + 1;
                }
            }
        }
    }
}

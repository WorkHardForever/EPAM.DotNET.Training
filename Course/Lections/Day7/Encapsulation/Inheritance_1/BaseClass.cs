using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1
{
    public class BaseClass
    {
        private int numBase;

        public int NumBase
        {
            get { return numBase; }
            set { numBase = (value > 0) ? value : 1; }
        }

        public BaseClass() { NumBase = 10; }
        public BaseClass(int number) { NumBase = number; }

        public int Square()
        {
            return numBase * numBase;
        }

        public override string ToString()
        {
            return String.Format("BaseClass has number {0}\n", numBase.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1
{
   public  class DerivedClass : BaseClass
    {
        private string name;
        private int numDerived;

        public DerivedClass() { Name = "Joe"; NumDerived = 100; }
        public DerivedClass(int a, int b, string name)
            : base(a)
        {
            NumDerived = b;
            this.name = name;
        }

        public int NumDerived
        {
            get { return numDerived; }
            set { numDerived = (value > 0) ? value : 100; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override string ToString()
        {
            return String.Format(" {0}\n {1} \t {2}\n", base.ToString(), name, numDerived);
        }
        public void Foo()
        {
            int sum = numDerived + NumBase;
            Console.WriteLine("Foo -> DerivedClass\n" + sum);
        }
    }
}

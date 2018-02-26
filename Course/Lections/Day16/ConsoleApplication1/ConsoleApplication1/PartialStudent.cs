using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public partial class Student
    {
        public override string ToString()
        {
            return string.Format("{0}  {1} ", this.StudentName, this.StudentAddress);
        }
    }
}

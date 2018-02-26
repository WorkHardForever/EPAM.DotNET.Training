using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Properties_1;

namespace Properties_2Console
{
    public class EmployeeService
    {
        Employee[] employees = { new Employee("Joe", 20000, "FS"), new Employee("Tim", 10000, "NT"), 
                                 new Employee("Nic", 100000, "PR"), new Employee("Petr") };

        public Employee this[string name]
        {
            get
            {
                if(name == null)
                    throw new ArgumentNullException(name);

                for (int i = 0; i < employees.Length; ++i)
                {
                    if (name.Equals(employees[i].GetName()))
                        return employees[i];
                }

                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

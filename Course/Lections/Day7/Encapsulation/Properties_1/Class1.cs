using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties_1
{
   public class Employee
    {
        private int salary;
        private string name;
        private string department;

        public string GetName() { return name; }
        public void SetName(string value) { name = value; }

        public string GetDepartment() { return department; }
        public void SetDepartment(string value) { department = value; }

        public int GetSalary() { return salary; }

        public void SetSalary(int value)
        {
            salary = (value >= 0 && value <= 1000000) ? value : 0;
        }

        public Employee(string name)
        {
            this.name = name;
            this.salary = 10000;
            this.department = "Customer Service";
        }
        public Employee(string name, int salary, string department)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
        }
        public override string ToString()
        {
          //return $"{name} earns {salary.ToString()} and is in the {department.ToLower()} department.";
            return String.Format("{0} earns ${1} and is in the {2} department.",
                                name, salary.ToString(), department.ToLower());
        }

         struct Revenue
        {
            string currency;
            double amount;
            public Revenue(string currency, double amount)
            {
                this.currency = currency;
                this.amount = amount;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DatabaseComponent;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = 
                ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            var employeeDb = new EmployeeDB(connectionString);

            IList<EmployeeDetails> employeeList = employeeDb.GetEmployees();
            foreach (var employeeDetailse in employeeList)
            {
                Console.WriteLine("\n\t{0} {1} {2}", employeeDetailse.TitleOfCourtesy,
                    employeeDetailse.FirstName, employeeDetailse.LastName);
            }

            Console.ReadKey();
            Console.Clear();

            var employee = new EmployeeDetails()
            {
                FirstName = "Elizavete",
                LastName = "Ivanova",
                TitleOfCourtesy = "Ms"
            };

            employeeDb.InsertEmployee(employee);

            foreach (var employeeDetailse in employeeDb.GetEmployees())
            {
                Console.WriteLine("\n\t{0} {1} {2}", employeeDetailse.TitleOfCourtesy,
                    employeeDetailse.FirstName, employeeDetailse.LastName);
            }
        }
    }
}

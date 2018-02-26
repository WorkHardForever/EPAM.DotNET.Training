using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseComponent
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TitleOfCourtesy { get; set; }

        public EmployeeDetails() { }

        public EmployeeDetails(int employeeID, string firstName, string lastName, string titleOfCourtesy)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            TitleOfCourtesy = titleOfCourtesy;
        }
    }
}

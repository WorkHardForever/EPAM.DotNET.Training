<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

public class Employee
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public decimal Salary { get; set; }
	public DateTime StartDate { get; set; }
}


void Main()
{
  var employees = new List<Employee>
 {
   new Employee { FirstName = "Ivan", LastName = "Ivanov", Salary = 94000, 
				  StartDate = DateTime.Parse("1/4/1992") },
   new Employee { FirstName = "Petr", LastName = "Petrov", Salary = 123000, 
                  StartDate = DateTime.Parse("12/3/1985") },
   new Employee { FirstName = "Andrey", LastName = "Andreev", Salary = 1000000, 
                  StartDate = DateTime.Parse("1/12/2005") }
  };


		
  var topSalaryEmployees = employees.Where(e => e.Salary > 100000);

  topSalaryEmployees.Dump();
}
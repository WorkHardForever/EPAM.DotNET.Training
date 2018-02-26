<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

class Customer
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
}

IEnumerable<Customer> _customers = new[]
{
	new Customer{ FirstName = "Luka", LastName="Abrus", Age = 41},
  	new Customer{ FirstName = "Keith", LastName="Harris", Age = 59},
	new Customer{ FirstName = "David", LastName="Pelton", Age = 25},
	new Customer{ FirstName = "John", LastName="Peoples", Age = 37},
	new Customer{ FirstName = "Toni", LastName="Poe", Age = 29},
	new Customer{ FirstName = "Jeff", LastName="Price", Age = 74}
};

void Main()
{
	List<string> customerLastNames = new List<string>();
	
	foreach (Customer customer in _customers)
	{
		customerLastNames.Add(customer.LastName);
	}
	
	customerLastNames.Dump();
	
	//versus
	
	IEnumerable<string> customerLastNames1 = 
					   _customers.Select(cust => cust.LastName);
	customerLastNames1.Dump();

}

// Define other methods and classes here

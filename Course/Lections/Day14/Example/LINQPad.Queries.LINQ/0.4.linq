<Query Kind="Program" />

public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
}
	
	
void Main()
{
  var people = new List<Person>
  {
	new Person { Name = "Holly", Age = 36 },
	new Person { Name = "Tom", Age = 9 },
	new Person { Name = "John", Age = 36 },
	new Person { Name = "William", Age = 13 },
	new Person { Name = "Robin", Age = 18 }
  };

 // IEnumerable<Person> person = people.Where();
  var adultPeopleNames = people
  .Where(p => p.Age >= 18)
  .Select(p=>p.Name);		

   adultPeopleNames.Dump();  
}

// Define other methods and classes here
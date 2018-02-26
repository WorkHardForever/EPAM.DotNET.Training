<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

//C# in Depth 5.5. Захват переменных в анонимных методах

delegate void MethodInvoker();

void Main()
{
	var list = new List<MethodInvoker>();
	int counter;
	for (int index = 0; index < 3; index++)
	{
		counter = index * 10;
		list.Add(delegate
		{
			Console.WriteLine(counter); 
			counter++;
		});
	}
	
	foreach(MethodInvoker t in list)
	{
		t();
	}
	
	list[0]();
	list[0]();
	list[1]();
	list[1]();
}

// Define other methods and classes here
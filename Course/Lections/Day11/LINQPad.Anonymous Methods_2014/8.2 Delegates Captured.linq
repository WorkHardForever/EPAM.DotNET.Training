<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

//C# in Depth 5.5. Захват переменных в анонимных методах 
delegate void MethodInvoker();

void Main()
{
	var list = new List<MethodInvoker>() ; 
	for (int index = 0; index < 3; index++) 
	{
		int counter; // <-- inside variable
		counter = index * 10; // #1 Создание экземпляра счетчика
		MethodInvoker del = delegate { Console.WriteLine(counter++); };
		list.Add(del);
//		delegate 
//		{ 
//				Console.WriteLine(counter); // #2 Отображение и приращение 
//				counter++; // захваченной переменной 
//		}); 
//		MethodInvoker del = delegate { 	Console.WriteLine(counter++); };
		//MethodInvoker del = new MethodInvoker(delegate { 	Console.WriteLine(counter++); });
		//del.Dump();
	}
	
	foreach (MethodInvoker t in list) 
	{ 
		t(); // #3 Выполняет все пять экземпляров делегата
		//t.Dump();
	} 

	list[0]();
	list[0]();
	list[0]();
	list[0]();
//
////list[0].Dump();
//
//	list[1]();
//	list[1]();
//	
//	//list[1].Dump();
}

// Define other methods and classes here
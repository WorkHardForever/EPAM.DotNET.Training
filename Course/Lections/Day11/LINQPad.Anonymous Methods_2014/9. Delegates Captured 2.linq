<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

//Происходит вот что: один дополнительный класс создается для содержания 
//переменной outer, а другой — для содержания переменной inner и ссылки на первый 
//дополнительный класс. По существу, каждая область видимости, которая содержит  
//захваченную переменную, получает собственный тип со ссылкой на следующую область 
//видимости, которая содержит захваченную переменную. В данном случае было два  
//экземпляра типа для содержания переменной inner, и оба они ссылаются на тот же  
//экземпляр типа, содержащий переменную outer. Другие реализации могут отличаться, но это 
//самый очевидный способ.

delegate void MethodInvoker();

void Main()
{
	MethodInvoker[] delegates = new MethodInvoker[2]; 
	int outside = 0; // #1 Создает экземпляр переменной только однажды 
	for (int i = 0; i < 2; i++) 
	{
		int inside = 0; // #2 Создает экземпляр переменной многократно 
		delegates[i] = delegate // #3 Захват переменной анонимным методом 
		{ 
			Console.WriteLine ("({0}, {1})", outside, inside);
			outside++;
			inside++;
		}; 
	} 
	
	delegates[0]();
	delegates[1]();
	
	delegates[0]();
	delegates[1]();
	
	delegates[0]();
	delegates[1]();
	
	delegates[0]();
	delegates[1]();
	
	
//	Process.Start (@"C:\Program Files (x86)\Red Gate\.NET Reflector\Desktop 7.7\Reflector.exe", 
//		Assembly.GetExecutingAssembly().Location);
}

// Define other methods and classes here
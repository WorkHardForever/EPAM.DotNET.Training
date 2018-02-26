<Query Kind="Program" />

// Captured variables have their lifetimes extended to that of the delegate:

static Func<int> Natural()
{
	int seed = 0;
	return () => seed++;
}

static void Main()
{
	Func<int> natural = Natural();
	
	Console.WriteLine (natural());
	natural.Dump();
	Console.WriteLine (natural());
	natural.Dump();
}


// delegate int F();
//
//static F Natural()
//
//	int seed = 0;
//	return () => seed++;	  
//}
//
//static void Main()
//{
//	F natural = Natural();
//	Console.WriteLine (natural());      
//	Console.WriteLine (natural());      
//}
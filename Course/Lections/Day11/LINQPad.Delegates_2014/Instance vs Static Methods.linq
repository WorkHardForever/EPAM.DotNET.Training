<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// When a delegate object is assigned to an instance method, the delegate object must maintain
// a reference not only to the method, but also to the instance to which the method belongs:

public delegate void ProgressReporter (int percentComplete);

static void Main()
{
	X x = new X();
	ProgressReporter p = x.InstanceProgress;
	p(99);                              
	p.Dump();
	
	//Console.WriteLine (p.Target);     
	//Console.WriteLine (p.Method);   
}

class X
{
	public void InstanceProgress (int percentComplete)
	{
		Console.WriteLine (percentComplete);
	}
}
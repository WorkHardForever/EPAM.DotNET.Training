<Query Kind="Program" />

delegate void DelegateType();

static DelegateType GetMethod()
{
	//DelegateType del = delegate { System.Console.WriteLine("Hello"); };
	
	return delegate { System.Console.WriteLine("Hello"); };
}

static void Main()
{
	DelegateType delegateInstance = GetMethod();
	delegateInstance();	
}
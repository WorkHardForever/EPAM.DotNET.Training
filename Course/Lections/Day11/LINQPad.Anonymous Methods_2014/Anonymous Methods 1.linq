<Query Kind="Program" />

delegate void DelegateType();

static DelegateType GetMethod()
{
	return new DelegateType(MethodBody);
}

static void MethodBody()
{
	System.Console.WriteLine("Hello");
}

static void Main()
{
	DelegateType delegateInstance = GetMethod();
	delegateInstance();
}
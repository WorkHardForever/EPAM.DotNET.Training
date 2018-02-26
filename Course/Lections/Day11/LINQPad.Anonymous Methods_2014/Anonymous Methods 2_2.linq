<Query Kind="Program" />

delegate int DelegateType(int a);

static DelegateType GetMethod()
{
	return  delegate(int a) { 
				System.Console.WriteLine("Hello  ");
				return ++a;
				};
}

static void Main()
{
	DelegateType delegateInstance = GetMethod();
	
	delegateInstance(4).Dump();
	delegateInstance.Dump();
}
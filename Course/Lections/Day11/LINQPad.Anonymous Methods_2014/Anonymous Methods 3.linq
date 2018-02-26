<Query Kind="Program" />

delegate void DelegateType();

static void Main()
{
	DelegateType delegateInstance = delegate{ 
					Console.WriteLine("Hello");
					};

	delegateInstance += delegate { 
					Console.WriteLine("Bonjour"); 
					};
	delegateInstance();
	delegateInstance.GetInvocationList().Dump();
	//delegateInstance.Dump();
	
	delegateInstance -= delegate { 
					Console.WriteLine("Bonjour"); 
					};
	delegateInstance();
	delegateInstance.GetInvocationList().Dump();
	//delegateInstance.Dump();
}
//1.Ananim.exe!!!!!!!
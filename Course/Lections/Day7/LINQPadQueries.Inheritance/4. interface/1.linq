<Query Kind="Program" />

public  sealed  class SimpleType : IDisposable 
{
	 public /*virtual*/void Dispose() 
	{ 
		Console.WriteLine(" Mathod Dispose - Implicit Interface Method Implementation (IIME)");
	} 
}

void Main()
{
	
	SimpleType st = new SimpleType();
	st.Dispose();
	IDisposable d = st;
	d.Dispose();
	
	
	//IEnumerable d1;
	//d1.
}
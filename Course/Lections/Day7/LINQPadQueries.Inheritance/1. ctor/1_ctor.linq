<Query Kind="Program" />

public class BaseClass
{
	private int numBase;
	
	public BaseClass(int number){
		numBase = number; 
		Console.WriteLine("BaseClass(int)");
	}
#region	
	public int NumBase
	{
		get{return numBase;}
		set{numBase = (value > 0) ? value: 1;}
	}	
	
	public int Square()
	{
		return numBase*numBase;
	}
#endregion

	public override string ToString()
	{
		return String.Format("BaseClass has number {0}\n", 
							  numBase.ToString());
	}
}

public class DerivedClass : BaseClass
{
	private string name;
	private int numDerived;
	
	public DerivedClass (int a, int b, string name): base(a) {
		numDerived = b;
		this.name = name; 
		Console.WriteLine("DerivedClass(int , int , string)");
	}
#region	
	public int NumDerived
	{
		get{return numDerived;}
		set{numDerived = (value > 0) ? value: 100;}
	}
	public string Name
	{
		get{return name;}
		set{name =  value;}
	}
	public void Foo()
	{
		int sum = numDerived + NumBase;
		Console.WriteLine("Foo -> DerivedClass\n" + sum);
	}
#endregion	
	public override string ToString()
	{
		return String.Format(" {0}\n {1} \t {2}\n", base.ToString(), name, numDerived);
	}
	
}
void Main()
{	
	BaseClass b1 = new BaseClass(7);
	b1.Dump("b1");	
	
	("\n").Dump();	
	
	DerivedClass d1 = new DerivedClass(8, -67, "Tom");
	d1.Dump("d1");	
}

// Define other methods and classes here

<Query Kind="Program" />

public class BaseClass
{
	private int numBase;
	
	public int NumBase
	{
		get{return numBase;}
		set{numBase = (value > 0) ? value: 1;}
	}
	
	public BaseClass(){NumBase = 10;}	
	public BaseClass(int number){NumBase = number; }
	
	public int Square()
	{
		return numBase*numBase;
	}
	
	public override string ToString()
	{
		return String.Format("BaseClass has number {0}\n", numBase.ToString());
	}
}

public class DerivedClass : BaseClass
{
	private string name ;
	private int numDerived ;
	
	public DerivedClass () {name = "Joe"; NumDerived = 100;}
	public DerivedClass (int a, int b, string name): base(a) {
		NumDerived = b;
		this.name = name; 
	}
	
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
	public override string ToString()
	{
		return String.Format(" {0}\n {1} \t {2}\n", base.ToString(), name, numDerived);
	}
	public void Foo()
	{
		int sum = numDerived + NumBase;
		Console.WriteLine("Foo -> DerivedClass\n" + sum);
	}
}
void Main()
{
	BaseClass b = new BaseClass(7);
	b.Dump();
	Console.WriteLine(b.Square());
	Console.WriteLine(b.ToString());
	
//	DerivedClass d1 = new DerivedClass(7, -67, "Tom");
//	d1.Dump();
//	Console.WriteLine(d1.Square());
//	d1.Foo();
//	Console.WriteLine(d1.ToString());	
	
	BaseClass d2 =  new DerivedClass(8, 4590, "Tim");
	d2.Dump();
	Console.WriteLine(d2.ToString());
	
}

// Define other methods and classes here

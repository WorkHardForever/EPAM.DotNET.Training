<Query Kind="Program" />

public class BaseClass
{
	protected int numBase = 10;

	public BaseClass(int number){numBase = number;}
	
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
	private string name = "Joe";
	private int numDerived = 100;
	
	public DerivedClass (int a, int b, string name): base(a) {
		numDerived = b;
		this.name = name; 
	}
	
	public override string ToString()
	{
		return String.Format(" {0}\n {1} \t {2}\n", base.ToString(), name, numDerived);
	}
	
	public void Foo()
	{
		int sum = numDerived + numBase;
		Console.WriteLine("Foo -> DerivedClass\n" + sum);
	}
}
void Main()
{
	BaseClass b = new BaseClass(7);
//b.
	Console.WriteLine(b.Square());	
	Console.WriteLine(b.ToString());
	
	DerivedClass d1 = new DerivedClass(7, -67, "Tom");
//d1.
	Console.WriteLine(d1.Square());
	d1.Foo();
	Console.WriteLine(d1.ToString());	
	

	
}

// Define other methods and classes here

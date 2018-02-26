<Query Kind="Program" />

public class SomeRefType
{
	public static int xStatic = 67;
	public int xInstance = 45;
	
	public SomeRefType()
	{
		Console.WriteLine("Instance ctor for class works!");
	}
		
	static SomeRefType()
	{
		Console.WriteLine("Static ctor for class works!");
	}
}

void Main()
{
	SomeRefType b = new SomeRefType();
	SomeRefType c = new SomeRefType();
}

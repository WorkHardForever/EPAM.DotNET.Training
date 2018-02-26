<Query Kind="Program" />

public class SomeRefType
{
	public static int xStatic;
	public int xInstance = 45;
	
	public SomeRefType()
	{
		Console.WriteLine("Instance ctor for class works!");
	}		
}
void Main()
{
	SomeRefType b = new SomeRefType();
	(SomeRefType.xStatic).Dump();
	SomeRefType c = new SomeRefType();
}
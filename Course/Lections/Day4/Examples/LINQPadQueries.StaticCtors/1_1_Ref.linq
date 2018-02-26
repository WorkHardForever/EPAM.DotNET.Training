<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

public class SomeRefType
{
	public static int xStatic= 10;
	public int xInstance = 45;
	
	public SomeRefType()
	{
		("Instance ctor for class works!").Dump();
	}
}

void Main()
{
	SomeRefType b = new SomeRefType();
	SomeRefType c = new SomeRefType();
}
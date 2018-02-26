<Query Kind="Program" />

public struct SomeStruct
{
	public void WriteLine()
	{
		System.Console.WriteLine("Hello");
	}	
}

static void Main()
{
	SomeStruct p;
	p.WriteLine();
}
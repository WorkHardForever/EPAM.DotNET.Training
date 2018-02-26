<Query Kind="Program" />

public struct SomeValType
{
	public static int xStatic = 123;
	public int xInstance;
	static SomeValType(){
		Console.WriteLine("Static ctor for struct works!");
	}
	
}

void Main()
{
	SomeValType a = new SomeValType();
	SomeValType b;
	a.Dump();
}
<Query Kind="Program" />

public struct SomeValType
{
	public static int xStatic = 123;
	public int xInstance;
	static SomeValType(){
		
	}
}

void Main()
{
	SomeValType a = new SomeValType();
	(SomeValType.xStatic).Dump();	
}
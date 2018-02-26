<Query Kind="Program" />

public struct SomeStruct
{
	public int x, y;
	public string s;
	
	public SomeStruct(int x, int y) 
	{
		this.x = x; 
		this.y = y; 
		
	}	
}

static void Main()
{	
	SomeStruct p = new SomeStruct (1, 1); 
	p.Dump("STRUCT   p=");
}
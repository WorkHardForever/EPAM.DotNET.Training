<Query Kind="Program" />

delegate double F(ref int a, int b = 2);

void Main()
{
	F f = (ref int x, int y )=> {x++; return x/y;};
	
	int a = 4;
	f(ref a).Dump();
	
	f.Dump();
	
	a.Dump("a=");
	
}

// Define other methods and classes here

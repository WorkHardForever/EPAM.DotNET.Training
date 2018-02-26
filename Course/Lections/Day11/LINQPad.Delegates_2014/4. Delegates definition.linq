<Query Kind="Program" />

delegate int Transformer (int x);

static void Main()
{
	Transformer t = Square; 
	t.Dump();
	
	int x = Square(3);
	x.Dump();
	
	int result = t(3); 
	Console.WriteLine (result);
	
	result = t.Invoke(4);
	Console.WriteLine (result);      
}

static int Square (int x) { return x * x; }
static int Cube (int x) { return x * x* x; }
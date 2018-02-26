<Query Kind="Program" />

delegate int Transformer (int x);

static void Main()
{
	Transformer t = Square; 
	t += Cube;
	t.GetInvocationList().Dump();
	int x = 2;
	t(x).Dump("Result:");
	x.Dump("x");
}

static int Square (int x) { return x * x; }
static int Cube (int x) { return x * x * x; }
<Query Kind="Program" />

delegate void Transformer (int x);

static void Main()
{
	Transformer t = null;   //  (int a)=>{};  //delegate(int a) { } ; //??????
	t.Dump();
	t += Cube;
	t += Cube;
	
	t.GetInvocationList().Dump();
	
	t(2);
	
	t = (Transformer)Delegate.RemoveAll(t, new Transformer(Cube));
	
	t?.GetInvocationList().Dump();
}

static void Square(int x) { x = x * x; x.Dump("Square"); }
static void Cube(int x) { x = x * x * x; x.Dump("Cube"); }
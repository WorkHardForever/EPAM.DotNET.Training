<Query Kind="Program" />

void Main()
{
	F f = Foo;
	f();
	f.Dump();
}
delegate void F();

static void Foo(){
	"Hello!!!!".Dump();
}
// Define other methods and classes here

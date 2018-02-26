<Query Kind="Program" />

static void Display(String s) 
{
	"Display(string)".Dump();
	Console.WriteLine(s);
}

static void Display<T>(T o)
{
	"Display(generic)".Dump();
	Display(o.ToString());
}


static void Main()
{
	Display("Hello");
	Display(123);
	Display<string>("Hello");
}
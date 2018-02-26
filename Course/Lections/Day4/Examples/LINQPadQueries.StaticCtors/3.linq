<Query Kind="Program" />

class Foo
{
	public static Foo Instance = new Foo();
	public static int xStatic = 23;
	Foo() { Console.WriteLine ("new Foo() = " + xStatic); }
}

void Main()
{
	Console.WriteLine("Foo.x=" + Foo.xStatic);
	//Process.Start (@"C:\Program Files (x86)\Red Gate\.NET Reflector\Desktop 8.0\Reflector.exe", 
		//Assembly.GetExecutingAssembly().Location);
}
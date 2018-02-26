<Query Kind="Program" />

struct Mutable
{
	public Mutable(int x, int y)
		: this()
	{
		X = x;
		Y = y;
	}
	public void IncrementX() { X++; }
	public int X { get; private set; }
	public int Y { get; set; }
}
class A
{
	public A() { Mutable = new Mutable(x: 5, y: 5); }
	public Mutable Mutable { get; set; }
}
void Main()
{
	A a = new A();
	a.Mutable.Y.Dump();
	a.Dump();
}


// Define other methods and classes here
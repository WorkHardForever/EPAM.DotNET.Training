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

void Main()
{
	Mutable ob = new Mutable(1, 1);
	ob.Y++;
	//ob.X++;
	ob.IncrementX();
	Console.WriteLine("X=" + ob.X);
	Console.WriteLine("Y=" + ob.Y);
}

// Define other methods and classes here
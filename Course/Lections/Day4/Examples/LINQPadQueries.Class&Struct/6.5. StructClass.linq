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
	Mutable[] lm = new Mutable []{
							new Mutable(x: 5, y: 5),
							new Mutable(x: 10, y: 20),
							};
	lm.Dump();
	lm[1].Y++;
	
	lm[1].IncrementX();
	lm.Dump();
}

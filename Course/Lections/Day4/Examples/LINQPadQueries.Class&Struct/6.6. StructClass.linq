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
	Mutable[] lm = new Mutable []{new Mutable(x: 5, y: 5)};
	IList<Mutable> lst = lm;
	lst.Dump();
	
	//lst[0].Y++;
	
	lst[0].IncrementX();
	lst.Dump();
}

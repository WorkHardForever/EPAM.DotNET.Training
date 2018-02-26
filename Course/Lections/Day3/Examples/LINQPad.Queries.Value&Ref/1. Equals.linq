<Query Kind="Program" />

void Main()
{	
	Point p1 = new Point(3,5);
	Point p2 = new Point(3,5);
	(p1.Equals(p2)).Dump();
	(p1==p2).Dump();
}

public  struct Point
{
	public int x1;
	public int y1;
	public Point(int x, int y)
	{
		x1 = x;
		y1 = y;
	}
}

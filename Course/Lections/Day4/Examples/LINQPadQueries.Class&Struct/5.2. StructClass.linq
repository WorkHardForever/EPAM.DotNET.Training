<Query Kind="Program" />

void Main()
{
	Rectangle r = new Rectangle();
	Point p = new Point();
	p.Dump();
	r.Dump();
}

public class Rectangle
{
	public string s;
	public int x;
	public Point topLeft, bottonRigth;

}

public struct Point
{
	public int x, y;
	public string s;

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
		this.s = string.Empty;
	}
}
<Query Kind="Program" />

void Main()
{
	var c = new ConstField();
	Console.WriteLine("MaxSize = " + ConstField.MaxSize.ToString());
	Console.WriteLine("MaxSize = " + c.x);
}

public class ConstField
{
	public const int MaxSize = 100;
	public int x = 5;
}

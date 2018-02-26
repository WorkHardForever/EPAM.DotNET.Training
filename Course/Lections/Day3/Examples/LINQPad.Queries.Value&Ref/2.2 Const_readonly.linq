<Query Kind="Program" />

void Main()
{
	var c = new ConstField();
	Console.WriteLine("MaxSize = " + ConstField.MaxSize.ToString());
	Console.WriteLine("x = " + ConstField.x.ToString());
	Console.WriteLine("y = " + c.y.ToString());
	Console.WriteLine("z = " + ConstField.z.ToString());
}

public class ConstField
{
	public const int MaxSize = 100;
	public static int x = 5;
	public readonly int y = 45;
	public static readonly int z = 50;	
}

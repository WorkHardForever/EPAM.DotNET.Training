<Query Kind="Program" />

static void Main()
{
	int[] values = { 1, 2, 3 };
	Util.TransformSquare (values);      
	values.Dump();
}

static int Square (int x) { return x * x; }

public class Util
{
  public static void TransformSquare (int[] values)
  {
	for (int i = 0; i < values.Length; i++)
	  values[i] = Square(values[i]);
  }
}






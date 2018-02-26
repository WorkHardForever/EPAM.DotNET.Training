<Query Kind="Program" />

static void Main()
{
	int[] values = { 1, 2, 3 };
	Util.TransformSquare (values);     
	values.Dump();
	
	values = new int[] { 1, 2, 3 };
	Util.TransformCube (values);       
	values.Dump();
}
static int Square (int x) { return x * x; }

static int Cube (int x) { return x * x * x; }

public class Util
{
  public static void TransformSquare (int[] values)
  {
	for (int i = 0; i < values.Length; i++)
	  values[i] = Square(values[i]);
  }
  
  public static void TransformCube (int[] values)
  {
	for (int i = 0; i < values.Length; i++)
	  values[i] = Cube (values[i]);
  }
}
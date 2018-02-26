<Query Kind="Program" />

static void Main()
{
	int[] values = { 1, 2, 3 };
	Util.TransformSquare (values);     
	values.Dump();
	
	values = new int[] { 1, 2, 3 };
	Util.TransformCube (values,2);       
	values.Dump();
}
static int Square (int x) { return x * x; }

static int Cube (int x) { return x * x * x; }

public class Util
{
  public static void Transform (int[] values, int flag = 1)
  {
	for (int i = 0; i < values.Length; i++)
	{
		switch(flag)
		{
		case 1: 
			values[i] = Square(values[i]);
			break;
		case 2:
			values[i] = Cube (values[i]);
			break;
		}
	  
	}
  }
}
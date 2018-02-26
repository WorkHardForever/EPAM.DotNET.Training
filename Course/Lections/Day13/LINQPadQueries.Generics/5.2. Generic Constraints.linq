<Query Kind="Program" />

public class RefSimple<T> where T : struct
{
	public T a;
	public static bool operator == (RefSimple<T> x, RefSimple<T> y)
	{
		return x.a == y.a;
	}
	public static bool operator != (RefSimple<T> x, RefSimple<T> y)
	{
		return x.a != y.a;
	}
}

static void Main()
{
	RefSimple<int> sruct1 = new RefSimple<int>();
	RefSimple<int> sruct2 = new RefSimple<int>();
	sruct1.a = 23;
	sruct2.a = 23;
	
	(sruct1 == sruct2).Dump();
	
	(sruct1.a == sruct2.a).Dump();	
}
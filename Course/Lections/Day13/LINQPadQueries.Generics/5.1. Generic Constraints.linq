<Query Kind="Program" />

public struct RefSimple<T> where T : class
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
	RefSimple<string> sruct1;
	RefSimple<string> sruct2;
	sruct1.a = new String ( "Hello".ToCharArray());
	sruct2.a = "Hello";
	
	(sruct1 == sruct2).Dump();
	
	(sruct1.a == sruct2.a).Dump();	
}
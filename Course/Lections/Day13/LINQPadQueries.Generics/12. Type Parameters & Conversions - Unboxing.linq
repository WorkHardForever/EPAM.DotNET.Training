<Query Kind="Program" />

// Unboxing conversions can also introduce ambiguities; again the solution is to first cast to object:

int Foo<T> (T x) 
{
	return (int) (object) x;
}

static void Main()
{
}
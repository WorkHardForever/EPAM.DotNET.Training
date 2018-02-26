<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

public dynamic Foo(dynamic x, dynamic y)
{
	return x / y;
}

public void Main()
{
	Console.WriteLine(Foo(7,2));
}
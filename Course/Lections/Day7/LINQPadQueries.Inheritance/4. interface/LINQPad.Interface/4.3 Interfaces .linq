<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// Помимо обеспечения полиморфизма между различными иерархиями классов,
// интерфейсы можно применять для поддержки механизма обратного вызова 
//(callback) — передача исполняемого кода в качестве одного из параметров
//другого кода

public interface ITransformer
{
	int Transform (int x);
}

class Squarer : ITransformer
{
	public int Transform (int x) { return x * x; }
}
class Cub : ITransformer
{
	public int Transform (int x) { return x * x *x; }
}
static void TransformAll (int[] values, ITransformer t)
{
	for (int i = 0; i < values.Length; i++)
		values[i] = t.Transform (values[i]);//  <<---
}

public static void Main()
{
	int[] values = { 1, 2, 3 };
	TransformAll (values, new Squarer());
	values.Dump();
	TransformAll (values, new Cub());
	values.Dump();
}

//A delegate design may be a better choice than an interface design if one or more of
//these conditions are true:
//• The interface defines only a single method.
//• Multicast capability is needed.
//• The subscriber needs to implement the interface multiple times.
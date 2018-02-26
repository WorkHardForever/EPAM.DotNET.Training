<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

	var x = Expression.Parameter(typeof(int), "x");
	var constExpr = Expression.Constant(1);
	var binExpr = Expression.Add(x,constExpr);
	var expression = Expression.Lambda<Func<int, int>>(binExpr,x);
	(expression.ToString()).Dump();
	(expression.Compile())(11).Dump();
	expression.Dump("Expression tree");
	

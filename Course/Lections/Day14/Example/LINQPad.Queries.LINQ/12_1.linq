<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

	Expression<Func<int, int>> expression = x => x + 1;
	(expression.Compile())(11).Dump();
	expression.Dump("Expression tree");


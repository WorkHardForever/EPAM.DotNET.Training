<Query Kind="Statements">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

Action[] actions = new Action[3];
int i = 0;
foreach (char c in "abc")
	actions [i++] = () => Console.Write (c);
//IndexOutOfRangeException 
for (int k = 0; k < 3; k++)
{
	actions[k](); 
}

foreach (Action a in actions) 
	a(); // ccc in C# 4.0
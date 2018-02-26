<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// Делегат может иметь более специализированные типы параметров, чем его целевой метод.
// Контрвариация (Контравиантность)

delegate void StringAction(string s);

static void Main()
{
	StringAction sa1 = new StringAction(ActOnObject);
	sa1("hello");
	StringAction sa2 = new StringAction(ActOnString);
	sa2("world");
	
	sa2 = sa1;
}

static void ActOnObject(object o)
{
	Console.WriteLine (o);   
}
static void ActOnString(string o)
{
	Console.WriteLine(o);
}
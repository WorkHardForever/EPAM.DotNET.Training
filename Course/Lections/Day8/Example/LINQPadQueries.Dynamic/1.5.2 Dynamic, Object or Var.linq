<Query Kind="Statements">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

dynamic dynExample = 10;
Console.WriteLine(dynExample.GetType());
dynExample = dynExample + 10;
Console.WriteLine(dynExample);

dynExample = "test ";
Console.WriteLine(dynExample.GetType());
dynExample = dynExample + 10;
Console.WriteLine(dynExample);

dynamic dynamicObject = new Object();
var anotherObject = dynamicObject;
Console.WriteLine(anotherObject.GetType());
//dynamicObject.Sum();
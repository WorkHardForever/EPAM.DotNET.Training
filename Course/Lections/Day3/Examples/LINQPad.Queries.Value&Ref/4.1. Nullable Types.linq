<Query Kind="Statements" />

// To represent null in a value type, you must use a special construct called a nullable type:
{
	int? i = null;          // Nullable Type
	(i == null).Dump();     // True
	i = 9;
	Console.WriteLine(i.GetType());
	i.Dump();
}
// Equivalent to:
{
	Nullable<int> i = new Nullable<int>();
	
	Console.WriteLine(i.HasValue);    // False
	Console.WriteLine(i);           
	i = 23;
	i.Value.Dump();
}
//IL
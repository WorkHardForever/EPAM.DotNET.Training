<Query Kind="Statements" />

// The ?? operator is the null coalescing operator, and it can be used with both 
// nullable types and reference types. It says “If the operand is non-null, give
// it to me; otherwise, give me a default value.”:

int? x = null;
int y = x.HasValue ? x.Value : 5; 
Console.WriteLine (y);	
x = 1234;
int y1 = x ?? 45;
Console.WriteLine (y1);	

int? a = null, b = null, c = null;
Console.WriteLine (a ?? b ?? c);
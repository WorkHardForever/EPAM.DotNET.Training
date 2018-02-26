<Query Kind="Statements" />

int x = 45;
dynamic d;
d = x;
object o;
o = x;
var v = x;

Console.WriteLine(d);
Console.WriteLine(d.GetType());

Console.WriteLine(o);
Console.WriteLine(o.GetType());

Console.WriteLine(v);
Console.WriteLine(v.GetType());

//int y = d;
//Console.WriteLine("y= " + y);
//
//y = (int)o;

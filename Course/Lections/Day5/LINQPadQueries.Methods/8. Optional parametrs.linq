<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
</Query>

private static void M(Int32 x = 9, String s = "A", DateTime dt = new DateTime())
{
	Console.WriteLine("x(int) = {0}, s(string) = {1}, dt(DataTime) = {2}", x, s, dt);
}

private static Int32 n = 0;

public static void Main()
{
	M();
	M(8, "X");
	M(5,  dt: DateTime.Now);
	M(n++, n++.ToString());
	n.Dump();
	M(s: (n++).ToString(), x: n++);
	n.Dump();
}

// Но есть нюанс - изменение имен параметров!
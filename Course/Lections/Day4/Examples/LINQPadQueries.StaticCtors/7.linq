<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

class Test
{
	public static string x = EchoAndReturn ("In type initializer");
	public static int t = 34;
	public static string EchoAndReturn (string s)
	{
		Console.WriteLine (s);
		return s;
	}
	
}

static void Main()
{
	Console.WriteLine("Starting Main");
	Console.WriteLine("Echo");
	
	Test.EchoAndReturn("After Echo!");
	string y = Test.x;
	
	if (y != null)
	{
		Console.WriteLine("After field access");
	}
}


<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

class Test
{
	public static string x = EchoAndReturn ("In type initializer");
	static Test(){}
	public static int t = 34;
	public static string EchoAndReturn (string s)
	{
		Console.WriteLine (s);
		return s;
	}
	public Test(){"GGGGG".Dump();}
}

static void Main()
{
	Console.WriteLine("Starting Main");
	Test t = new Test();
	Console.WriteLine("After echo");
	
	Test.EchoAndReturn("Echo!");
	Console.WriteLine("After echo");
	
	string y = Test.x;
	
	if (y != null)
	{
		Console.WriteLine("After field access");
	}
	
}

//Результаты выполнения весьма разнообразны. 
//Среда выполнения может принять решение о запуске
//инициализатора типа по загрузке сборки, чтобы начать с

//In type initializer
//Starting Main
//Echo!
//After echo
//After field access

//Или, возможно, он будет работать, при первом запуске статического метода  ...
//Starting Main
//In type initializer
//Echo!
//After echo
//After field access

//Или даже ждать первого обращения к полю ...
//Starting Main
//Echo!
//After echo
//In type initializer
//After field access
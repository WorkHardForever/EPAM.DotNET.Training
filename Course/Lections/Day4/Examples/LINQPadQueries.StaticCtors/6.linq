<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

class Test
{
	static object _obj = new object();
	static Test() { }
}

static void Main()
{
	Test t = new Test();	
}
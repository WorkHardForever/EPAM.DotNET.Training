<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

class Test
{
	public static object _obj;
	
	static Test()
	{
		_obj = new object();
	}
}

static void Main()
{
	Test t = new Test();	
}
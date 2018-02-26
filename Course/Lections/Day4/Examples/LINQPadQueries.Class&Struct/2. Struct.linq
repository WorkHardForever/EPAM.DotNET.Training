<Query Kind="Program" />

public struct SomeStruct
{
	public int x, y;
	public string s;

	//В спецификации языка C# сказано, что пользователю запрещается
	//создавать конструктор по умолчанию явно, поскольку любая структура
	//содержит его неявно
	
}

static void Main()
{
	SomeStruct p = new SomeStruct (); 
	p.Dump("STRUCT   p=");
	
	SomeStruct p1 = default(SomeStruct); 
	p1.Dump("STRUCT   p1=");
}
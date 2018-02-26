<Query Kind="Program" />

//Aактически реальные делегаты всегда являются наследниками MulticastDelegate!
delegate void MyDelegate();

static void Method() { }

static void Main()
{
	MyDelegate del = new MyDelegate(Method);
	Console.WriteLine(del.GetType().BaseType.Name);
}



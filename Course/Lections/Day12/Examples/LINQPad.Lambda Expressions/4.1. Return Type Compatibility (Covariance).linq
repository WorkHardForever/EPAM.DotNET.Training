<Query Kind="Program" />

// Возможность построить один делегат, который может указывать на методы,
// возвращающие типы классов, связанные классическим наследованием (не value type)
// Ковариация позволяет методу иметь тип возвращаемого значения, 
// степень наследования которого больше, чем указано в делегате
// Ковариация (ковариантность)
// Relax delegates
delegate object ObjectRetriever();

static void Main()
{
	ObjectRetriever o1 = new ObjectRetriever(RetriveString);
	ObjectRetriever o2 = new ObjectRetriever(RetriveObject);
	
	object result = o1();
	Console.WriteLine (result);

	o1 = o2;
	object result1 = o1();
	Console.WriteLine(result1);

	o2 = o1;
	object result2 = o2();
	Console.WriteLine(result2);
}

static string RetriveString() { return "return string"; }
static int RetriveInteger() { return 45; }
static object RetriveObject() { return "return object"; }
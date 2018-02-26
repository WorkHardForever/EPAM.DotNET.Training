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
	ObjectRetriever o = new ObjectRetriever(RetriveInteger);	// <--- значимый тип вот и бесится

	object result = o();
	Console.WriteLine(result);	
}

static string RetriveString() { return "return string"; }
static int RetriveInteger() { return 45; }
static object RetriveObject() { return "return object"; }
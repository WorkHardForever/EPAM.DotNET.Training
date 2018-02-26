<Query Kind="Program" />

// Возможность построить один делегат, который может указывать на методы,
// возвращающие типы классов, связанные классическим наследованием (не value type-ы)
// Ковариация (ковариантность)
// Relax delegates

delegate object ObjectRetriever();

static void Main()
{
	ObjectRetriever o = new ObjectRetriever(RetriveString);
	object result = o();
	Console.WriteLine (result);
}

static string RetriveString() { return "return string"; }
//static int RetriveInteger() { return "return int"; }
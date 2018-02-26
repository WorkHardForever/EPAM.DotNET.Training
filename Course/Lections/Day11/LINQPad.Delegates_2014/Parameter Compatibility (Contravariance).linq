<Query Kind="Program" />

// Делегат может иметь более специализированные типы параметров, чем его целевой метод.
// Контрвариация (Контравиантность) - это в

delegate void StringAction (String s);

static void Main()
{
	StringAction sa = new StringAction(ActOnObject);
	sa("hello");
	//DisplayAction del = Display;
	//del(new Dog());
}

static void ActOnObject(object o)
{
	o.Dump();   // hello
}
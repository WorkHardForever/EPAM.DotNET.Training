<Query Kind="Program" />

//Делегат при описании создает новый тип!!!
//При этом два делегата с одинаковой сигнатурой являются разными типами,
//не совместимыми (не приводимыми) между собой.

delegate void Delegate1();
delegate void Delegate2();

static void Method() { }

static void Main()
{
	Delegate1 del1 = Method;
	del1.Dump();
	Delegate2 del2 = Method;
	del2.Dump();
	
	del2 = del1.Invoke;
	del2.Dump();	
}
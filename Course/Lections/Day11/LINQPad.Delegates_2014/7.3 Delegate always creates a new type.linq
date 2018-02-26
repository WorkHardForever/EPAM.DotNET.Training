<Query Kind="Program" />

//Делегат при описании создает новый тип!!!
//При этом два делегата с одинаковой сигнатурой являются разными типами,
//не совместимыми (не приводимыми) между собой.

delegate void Delegate1();
delegate void Delegate2();

static void Method() { }

static void Main()
{
	Delegate1 del1 = new Delegate1(Method);
	del1.Dump();
	Delegate2 del2 = new Delegate2(Method);
	del2.Dump();
	
	Delegate2 del3 = new Delegate2(del1);//Законно!
	del3.Dump();
}
<Query Kind="Program" />

//Делегат при описании создает новый тип!!!
//При этом два делегата с одинаковой сигнатурой являются разными типами,
//не совместимыми (не приводимыми) между собой.

delegate void MyDelegate1();
delegate void MyDelegate2();

static void Method() { }

static void Main()
{
	MyDelegate1 del1 = new MyDelegate1(Method);
	del1.Dump();
	MyDelegate2 del2 = new MyDelegate2(Method);
	del2.Dump();
	
	del1 = del2;	
}
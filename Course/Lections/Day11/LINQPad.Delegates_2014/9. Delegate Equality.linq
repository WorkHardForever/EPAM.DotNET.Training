<Query Kind="Program" />

// Delegate instances are considered equal if they have the same method targets:

delegate void D();

static void Main()
{
	D d1 = Method1;
	D d2 = Method1;
	Console.WriteLine (d1 == d2);         
}

static void Method1() { }

#region Equality
// ИТАК!!!!!
// Сравнивать мы можем только делегаты одного типа, т.к. делегат это класс,
// то следовательно компилятор может сравнивать только данные одного типа
// и тем более это еще и sealed класс.
// Два делегата равны, тогда и только тогда, когда:
// 1.	Они одного типа.
// 2.	Инкапсулируют один и тот же метод 
// 3.	И если это еще и instance метод, то и объект на котором вызывается
// данный метод, должен быть один и тот же.
#endregion
<Query Kind="Program" />

// Delegate instances are considered equal if they have the same method targets:
public delegate void ProgressReporter (int percentComplete);

static void Main()
{
	X x = new X();
	ProgressReporter p1 = x.InstanceProgress;
	ProgressReporter p2 = x.InstanceProgress;
	
	Console.WriteLine(p1 == p2);	   
}

public class X
{
	public void InstanceProgress(int percentComplete)
	{
		Console.WriteLine (percentComplete);
	}
}

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
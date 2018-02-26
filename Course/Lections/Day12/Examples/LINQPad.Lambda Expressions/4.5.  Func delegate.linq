<Query Kind="Program" />

public delegate TResult Func1<T, TResult>(T arg);

public class Base {}
public class Derived : Base {}

public static Derived MyMethod(Base b)
{
	return b as Derived ?? new Derived();
}

//public static Base MyMethod2(Derived b)
//{
//	return b as Base ?? new Base();
//}

static void Main()
{
	Func1<Base, Derived> f1 = MyMethod;
	Func1<Derived, Base> f2 = MyMethod;	
	
//	Func1<Base, Derived> f3 = MyMethod2;
//	Func1<Derived, Base> f4 = MyMethod2;
}
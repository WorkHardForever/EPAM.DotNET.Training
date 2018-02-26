<Query Kind="Program" />

public delegate TResult MyFunc<T, TResult>(T arg);

public class Base {}
public class Derived : Base {}

public static Derived MyMethod(Base b)
{
	return b as Derived ?? new Derived();
}
public static Base MyMethod2(Derived b)
{
	return b as Derived ?? new Derived();
}

static void Main() 
{
	MyFunc<Base, Derived> f1 = MyMethod;	 // Derived der = MyMethod(new Base())
	MyFunc<Derived, Base> f2 = MyMethod /*f1*/; 	 // Base der = MyMethod(new Derived())
	
	//MyFunc<Base, Derived> f3 = MyMethod2;	 // Derived der = MyMethod(new Base()) <--- Error
	MyFunc<Derived, Base> f4 = MyMethod2;	 // Base der = MyMethod(new Derived())
}
<Query Kind="Program" />

void Main(){

	A objectA = new B();
	objectA.Function();
	objectA.C();
	
}

public class A
{
	public virtual void Function()
	{
	  Console.WriteLine("Метод класса A");
	}
	public virtual void C()
	{
		 Console.WriteLine("Метод C класса A");
	}
}
  
public class B : A
{
	public new void Function()
	{
	  Console.WriteLine("Метод класса B");
	}
	public override  void C()
	{
		 Console.WriteLine("Метод C класса B");
	}
}

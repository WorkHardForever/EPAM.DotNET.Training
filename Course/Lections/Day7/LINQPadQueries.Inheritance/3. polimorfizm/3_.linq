<Query Kind="Program" />

void Main(){
	A objectA = new B();
	objectA.Function();
	
	objectA = new C();
	objectA.Function();
	
	B objectB = (B)objectA;
	objectB.Function();
}

public class A
{
	public virtual void Function()
	{
	  Console.WriteLine("Метод класса A");
	}
}
  
public class B : A
{
	public new virtual void Function()
	{
	  Console.WriteLine("Метод класса B");
	}
}

public class C : B
{
	public override void Function()
	{
	  Console.WriteLine("Метод класса C");
	}
}
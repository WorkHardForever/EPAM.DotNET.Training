<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

interface IDraw
{
	void Draw();
}
	
public class BaseClass : IDraw
{
	void IDraw.Draw()
	{
		Console.WriteLine("BaseClass");
	}
}
	
public class DerivedClass : BaseClass
{
	public void Draw()
	{
		Console.WriteLine("DerivedClass");
	}
}

void Main()
{
	BaseClass baseClass = new BaseClass();
	baseClass.Draw(); 
	DerivedClass derivedClass = new DerivedClass();
	derivedClass.Draw();
	
	baseClass = derivedClass;
	baseClass.Draw();
	
	IDraw draw = new BaseClass();
	draw.Draw();
	
	draw = new DerivedClass();
	draw.Draw();
}
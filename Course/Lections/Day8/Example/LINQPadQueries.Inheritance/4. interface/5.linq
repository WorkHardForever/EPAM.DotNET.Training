<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

interface IDraw
{
	void Draw();
}

public class BaseClass : IDraw
{
	public void Draw()
	{
		Console.WriteLine("Implicit implementation method interface IDraw");
	}
}

public class DerivedClass : BaseClass, IDraw
{
	public new void Draw()
	{
		Console.WriteLine("Hiding method (interface) of base class");
	}
}

void Main()
{
//	BaseClass baseClass = new BaseClass();
// 	baseClass.Draw();     
// 	DerivedClass derivedClass = new DerivedClass();
//	derivedClass.Draw();
//	
//	baseClass = derivedClass;
//	baseClass.Draw();	
	
	IDraw draw = new BaseClass();
	draw.Draw();
	
	draw = new DerivedClass();
	draw.Draw();
}
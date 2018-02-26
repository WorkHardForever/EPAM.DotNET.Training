<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{	
	A a ;
	
	B b = new B();
	a = b;  	a. M();
	
	C c = new C();
	a = c;   	a. M();	
	b = c;  	b. M();
	
	D d = new D();
	a = d;  	a. M();
	b = d;  	b. M();	
	c = d;  	c. M();
}
class	A		
{	
	public	virtual	void	M()	{	
	Console.WriteLine("метод M() класса A");	
	}	
}	
class	B:	A		
{	
	public	override	void	M()	{	
	Console.WriteLine("метод M() класса B");	
	}	
}	
class	C:	B	
{	
	new public	virtual	void	M()	{	
	Console.WriteLine("метод M() класса C");	
	base.M();
	}	
}	
class	D:	C	
{	
	public	override	void	M()	{	
	Console.WriteLine("метод M() класса D");	
	}	
}
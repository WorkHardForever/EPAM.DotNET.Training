<Query Kind="Program" />

void Main()
{	
	A a = new A();
	a.M();
	
	"\n".Dump();
	B b = new B();
	b. M();

	a = b;
	a. M();
	
	"\n". Dump();
	C c = new C();
	c. M();

	a = c;
	a. M();
	
	b = c;
	b. M();
	
	"\n". Dump();
	D d = new D();
	d. M();

	a = d;
	a. M();

	b = d;
	b. M();
	
	c = d;
	c. M();
}
class	A		
{	
	public	virtual	void	M()	{	Console.WriteLine("метод M() класса A");	}	
}	
class	B:	A		
{	
	public	override	void	M()	{	Console.WriteLine("метод M() класса B");	}
	}	
class	C:	B	
{	
	 public	override	void	M()	{	Console.WriteLine("метод M() класса C");	}	
}	
class	D:	C	
{	
	public	override	void	M()	{	Console.WriteLine("метод M() класса D");	}	
}
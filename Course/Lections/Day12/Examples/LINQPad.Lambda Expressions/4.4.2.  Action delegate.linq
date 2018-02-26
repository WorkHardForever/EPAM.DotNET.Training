<Query Kind="Program" />

public delegate void Delegat<in T>(T obj);

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Main()
{
	Delegat<Dog> action = Foo;
	Delegat<Animal> action1 = Foo;
	action = action1;
	
}

void Foo(Animal a)
{
	return;
}
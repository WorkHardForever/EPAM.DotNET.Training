<Query Kind="Program" />

public delegate T Delegate<T> ();

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Main()
{
	Delegate<Dog> action1 = Foo;
	Delegate<Animal> action2 = Foo;
	action2 = action1;
	
}

Dog Foo()
{
	Dog animal = null;
	//......
	return animal;
}
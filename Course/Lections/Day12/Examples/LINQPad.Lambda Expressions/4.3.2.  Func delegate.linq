<Query Kind="Program" />

public delegate T1 Func<out T1>();

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Main()
{
	Func<Dog> action1 = Foo;
	Func<Animal> action2 = Foo;
	action2 = action1;
}

Dog Foo()
{
	Dog animal = null;
	//......
	return animal;
}

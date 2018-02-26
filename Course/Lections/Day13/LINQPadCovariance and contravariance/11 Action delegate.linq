<Query Kind="Program" />

public delegate void Action<in T>(T obj);

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Main()
{
	Action<Animal> action = Foo;     // void Action(Animal obj);	Action(new Dog())   <-- Error
	Action<Dog> action1 = action;	 // void Action(Dog obj);		Action(new Dog())
	Action<Cat> action2 = action;	 // void Action(Cat obj);		Action(new Dog())
}

void Foo(Animal a)
{
	return;
}
<Query Kind="Program" />

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Write (Animal[] a)//массивы ковариантны
{
	a.Dump();
	//a[0] = new Cat();
}

void Main()
{
	Write (new Animal[] { new Animal() } );	
	Write (new Cat[]    { new Cat()    } );	
	Write (new Dog[]    { new Dog()    } );	
}
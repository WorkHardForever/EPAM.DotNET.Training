<Query Kind="Program" />

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Write<T>(List<T> a)where T:Animal
{
	a.Dump();
	//a[0] = new Cat();
}

void Main()
{
	Write (new List<Animal> { new Animal() } );	
	Write (new List<Cat>    { new Cat()    } );	
	Write (new List<Dog>    { new Dog()    } );	
}
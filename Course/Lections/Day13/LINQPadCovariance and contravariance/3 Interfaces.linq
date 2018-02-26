<Query Kind="Program" />

class Animal { }
class Dog : Animal { }
class Cat : Animal { }

void Write (IEnumerable<Animal> a)
{
	a.Dump();//не изменяем вхолящие данные!(foreach)
}

void Main()
{
	Write (new List<Animal> { new Animal() } );	
	Write (new List<Cat>    { new Cat()    } );	
	Write (new List<Dog>    { new Dog()    } );	
	IEnumerable<Dog> g = new List<Dog>();
	IEnumerable<Animal> f = g; //<--ковариация
}
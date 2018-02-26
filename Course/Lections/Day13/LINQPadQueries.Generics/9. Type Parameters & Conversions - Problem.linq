<Query Kind="Program" />

//операция приведения типа C# может выполнять несколько видов преобразования, включая:
//• Numeric conversion (числовые преобразования)
//• Reference conversion (ссылочные преобразования)
//• Boxing/unboxing conversion упаковывающие.распаковывающие преобразования)
//• Custom conversion (специальные преобразования - via operator overloading)
//The decision as to which kind of conversion will take place happens 
//at compile time, based on the known types of the operands. T
//his creates an interesting scenario with generic type parameters, 
//because the precise operand types are unknown at compile time.

// The most common scenario is when you want to perform a reference conversion:

StringBuilder Foo<T> (T arg)
{
	if (arg is StringBuilder)
		// Will not compile: Cannot convert T to StringBuilder
		return (StringBuilder) arg;   
	//custom conversion
	/*...*/
	return null;
}

static void Main()
{
}
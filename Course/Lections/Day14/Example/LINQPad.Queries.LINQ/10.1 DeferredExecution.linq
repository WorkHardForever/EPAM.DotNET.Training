<Query Kind="Statements" />

var	numbers	=	new	List<int>();	
numbers.Add	(1);	

IEnumerable<int>	query	=	numbers.Select	(n	=>	n	*	10);	
numbers.Add	(2);

foreach(var	temp	in	query)	
	 Console.WriteLine(temp);
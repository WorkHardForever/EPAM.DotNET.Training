<Query Kind="Statements" />

var	numbers	=	new	List<int>()	{	1,	2	};	

IEnumerable<int>	timesTen	=	numbers.Select	(n	=>	n	*	10).ToList();

foreach(var	temp	in	timesTen)	
	Console.WriteLine(temp);	


numbers.Clear();

foreach(var	temp	in	timesTen)	
	Console.WriteLine(temp);
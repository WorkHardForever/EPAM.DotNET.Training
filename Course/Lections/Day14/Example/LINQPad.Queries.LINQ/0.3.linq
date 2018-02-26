<Query Kind="Statements" />

	int[]	numbers	= {5, 12, 3};	

	var	query =	numbers
	.Where(n => n < 10)
	.OrderBy(n => n)
	.Select(n => n * 10);					
	
	foreach	(int	number	in	evens)	Console.WriteLine(number);	
	
//	var	query =	Enumerable.Select(
//				  Enumerable.OrderBy(
//					Enumerable.Where(numbers, 
//						n => n < 10
//					),n => n
//				  ),n => n * 10
//			   );
//			  
//	foreach	(int number	in	query)	Console.WriteLine(number);	
	
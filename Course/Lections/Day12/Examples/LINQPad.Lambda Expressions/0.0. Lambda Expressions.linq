<Query Kind="Program" />

delegate int Transformer (int i);
static void Main()
{
	Transformer sqr = x => x * x;
	Console.WriteLine (sqr(3));    
	
	
	Transformer sqrBlock = x => { return x * x; };
	Console.WriteLine (sqrBlock(3));
	
	
	Func<int,int> sqrFunc = x => x * x;
	Console.WriteLine (sqrFunc(3));
	

	Func<string,string,int> totalLength = 
					(s1, s2) => s1.Length + s2.Length;					
	int total = totalLength ("hello", "world");
	total.Dump ("total");
	
	
	Func<int,int> sqrExplicit = (int x) => x * x;
	Console.WriteLine (sqrExplicit(3));
}
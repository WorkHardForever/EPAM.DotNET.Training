<Query Kind="Program" />

void Main()
{
//	int x = 1, y = 2, z = 3;
//	Sum(x++,y+=3,z*=4).Dump();
//	x.Dump();
//	y.Dump();
//	z.Dump();
	int x1 = 2;
	Sum(x1++,x1+=2,x1*=2).Dump();
	x1.Dump();
}

int Sum(int a, int b, int c)
{
	return a + b + c;
} 
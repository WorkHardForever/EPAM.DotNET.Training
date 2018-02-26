<Query Kind="Program" />

void Main()
{
	int x = 1;
	int result = Sum(second:x++, first:x+=2);
	result.Dump("result");
	x.Dump("x=");
}

int Sum(int first, int second)
{
	first.Dump("first");
	second.Dump("second");
	return first + second;
}
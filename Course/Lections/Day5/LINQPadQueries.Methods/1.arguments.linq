<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
</Query>

void Main()
{
	int i = 1;
	int j = 2;
	int result = Sum(i++, i+j);
	result.Dump("result");
}

int Sum(int first, int second)
{
	first.Dump("first");
	second.Dump("second");
	return first + second;
}


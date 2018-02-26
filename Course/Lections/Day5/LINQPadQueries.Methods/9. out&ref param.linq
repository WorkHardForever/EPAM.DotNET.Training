<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
</Query>

void Main()
{
	int x;
	int y=1;
	
	OutParametrs(out x);
	x.Dump("OutParametrs(out x)=");
	
	RefParametrs(ref y);
	y.Dump("RefParametrs(ref y)=");
	
	ValParametrs(y);
	y.Dump("ValParametrs(y)");
}

void OutParametrs(out int x)
{
	x = 100;
}

void RefParametrs(ref int x)
{
	x = 10;
}

void ValParametrs(int x)
{
	x = 11;
}
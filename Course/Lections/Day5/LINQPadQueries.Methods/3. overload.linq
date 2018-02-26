<Query Kind="Program" />

void Main()
{
	int x = 7;
	F(x);
}
void F(double a)
{
	a.Dump("double");
}
void F(float a)
{
	a.Dump("float");
}
//void F(decimal a)
//{
//	a.Dump("decimal");
//}
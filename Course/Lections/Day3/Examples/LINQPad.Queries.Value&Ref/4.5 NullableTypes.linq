<Query Kind="Program" />

void Main()
{
	int? x = new Nullable<int>(5);
	object o = x;
	o.GetType().Dump();
	int y = 8;
	o = y;
	o.GetType().Dump();	
}
//IL
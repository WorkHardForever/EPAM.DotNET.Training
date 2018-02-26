<Query Kind="Statements" />

{
int x = 5;

object o = x;

o.Dump();

short y = (short)o;

y.Dump();
}


{
short x = 5;
object o = x;

o.Dump();

int y = (short)o;

y.Dump();
}
<Query Kind="Statements" />

int x = 5;

object o = x;
o.Dump();


o = null;

int y = (int)o;

y.Dump();
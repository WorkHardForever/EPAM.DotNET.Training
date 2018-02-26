<Query Kind="Statements" />

long x = 12345678912334;
x.Dump("long x=");

float f = x;
f.Dump("float f = ");

x = (long)f;
x.Dump("new long x = ");

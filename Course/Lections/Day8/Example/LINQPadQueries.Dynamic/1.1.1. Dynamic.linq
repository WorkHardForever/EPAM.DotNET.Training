<Query Kind="Statements">
  <Namespace>System.Dynamic</Namespace>
</Query>

int i = 7;
dynamic d = i;
int j = d;       

j.Dump();


short s =(short) d;
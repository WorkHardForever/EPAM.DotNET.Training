<Query Kind="Statements" />

Action[] actions = new Action[3];
	
	int i = 0;
	int j = 10;
	actions[0] = () => Console.WriteLine(i);
	i = 1;
	actions[1] = () => Console.WriteLine(j);
	i = 2;
	actions[2] = () => Console.WriteLine(i+j);
	i = 3;
	
	foreach (Action a in actions) a();
	
	actions.Dump();
	
	i = 67;
	foreach (Action a in actions) a();
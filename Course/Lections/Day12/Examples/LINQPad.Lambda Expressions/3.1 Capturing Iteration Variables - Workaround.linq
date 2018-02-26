<Query Kind="Statements" />

Action[] actions = new Action[3];

for (int i = 0; i < 3; i++)
{
	actions [i] = () => Console.Write (i);
}

actions [0] ();
actions [1] ();
actions [2] ();

actions.Dump();

foreach (Action a in actions) a();
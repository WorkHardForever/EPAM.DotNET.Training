<Query Kind="Statements" />

Action[] actions = new Action[3];
int[] array = {0, 1, 2};

foreach  (int j in array)
{
	actions [j] = () => Console.Write (j);
}


actions [0] ();
actions [1] ();
actions [2] ();

actions.Dump();

foreach (Action a in actions) a();
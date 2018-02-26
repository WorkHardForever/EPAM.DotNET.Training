<Query Kind="Statements" />

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
				from n in names
				select n.Replace ("а", "").Replace ("e", "").Replace ("i", "")
								.Replace ("o", "").Replace ("u", "");

query = from n in query where n.Length > 2 orderby n select n;

query.Dump();
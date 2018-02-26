<Query Kind="Statements" />

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
					from  n in names
					where n.Length > 2
					orderby n
					select n.Replace ("а","").Replace("e","").Replace ("i", "")
							.Replace ("о","").Replace("u","");

query.Dump();
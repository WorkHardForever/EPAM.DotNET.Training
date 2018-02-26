<Query Kind="Statements" />

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
				from n in names
				select n.Replace ("а", "").Replace ("e", "").Replace ("i", "")
								.Replace ("o", "").Replace ("u", "")
				into noVowel
					where noVowel.Length > 2 orderby noVowel select noVowel;

query.Dump();
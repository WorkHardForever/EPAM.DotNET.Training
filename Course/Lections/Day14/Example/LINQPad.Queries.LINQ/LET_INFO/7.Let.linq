<Query Kind="Statements" />

string[] names = { "Tom", "Harry", "Mary","Dick","Jay" };

IEnumerable<string> query =
			from n in names
			let vowelless = n.Replace ("a", "").Replace ("e", "").Replace ("i", "")
							.Replace ("o", "").Replace ("u", "")
			where vowelless.Length > 2
			orderby vowelless
			select n;
			
query.Dump();
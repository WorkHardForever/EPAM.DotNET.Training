<Query Kind="Statements" />

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

var intermediate = from n in names
	select new
	{
		Original = n,
		Vowlless = n.Replace("а", "").Replace ("e", "").Replace ("i", "")
					.Replace ("o", "").Replace ("u", "")
	};
IEnumerable<string> query =
				from n in intermediate
				where n.Vowlless.Length >2 
				select n.Original;

query.Dump();
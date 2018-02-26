<Query Kind="Statements" />

IEnumerable<char>  names = "Tom Dick Harry Mary Jay";
string voewls = "aeiou";

for (int i= 0; i<voewls.Length;++i)
{
	char voewl = voewls[i];
	 names = from names.Where(c => c!=voewl);
}

foreach (var c in names)
	Console.Write(c);
	
IEnumerable<string> query =
				from n in names
				select n.Replace ("а", "").Replace ("e", "").Replace ("i", "")
								.Replace ("o", "").Replace ("u", "");

query = from n in query where n.Length > 2 orderby n select n;

query.Dump();
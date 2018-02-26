<Query Kind="Statements" />

IEnumerable<char>  names = "Tom Dick Harry Mary Jay";
string voewls = "aeiou";

for (int i= 0; i<voewls.Length;++i)
{
	char voewl = voewls[i];
	 names = names.Where(c => c!=voewl);
}

foreach (var c in names)
	Console.Write(c);
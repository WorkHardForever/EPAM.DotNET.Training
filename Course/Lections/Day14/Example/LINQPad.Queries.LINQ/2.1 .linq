<Query Kind="Statements" />

IEnumerable<char>  names = "Tom Dick Harry Mary Jay";
string voewls = "aeiou";

for (int i= 0; i<voewls.Length;++i  )
{
	 names = names.Where(c => c!=voewls[i]);
}

foreach (var c in names)
	Console.Write(c);
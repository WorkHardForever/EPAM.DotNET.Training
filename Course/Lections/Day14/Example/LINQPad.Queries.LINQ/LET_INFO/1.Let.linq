<Query Kind="Statements" />

//необходимо удалить все гласные из списка имен и затем представить в алфавитном порядке те из них, длина которых все еще превышает два символа.
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query = names
.Select (n => n.Replace ("a", "").Replace ("e", "").Replace ("i", "")
.Replace ("о", "").Replace ("u", ""))
.Where (n => n.Length > 2)
.OrderBy (n => n) ;


query.Dump();
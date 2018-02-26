<Query Kind="Statements" />

//Вместо того чтобы вызывать метод Replace из string пять раз, 
//мы могли бы удалить гласные из строки более эффективно посредством регулярного выражения:
//n => Regex.Replace (n, "[aeiou]", "")
//Однако метод Replace из string обладает тем преимуществом, что работает также в запросах к базам данных.

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query = names
.Select (n => Regex.Replace (n, "[aeiou]", ""))
.Where (n => n.Length > 2)
.OrderBy (n => n) ;


query.Dump();
<Query Kind="Statements" />

//Вместо того чтобы вызывать метод Replace из string пять раз, 
//мы могли бы удалить гласные из строки более эффективно посредством регулярного выражения:
//n => Regex.Replace (n, "[aeiou]", "")
//Однако метод Replace из string обладает тем преимуществом, что работает также в запросах к базам данных.
 
IEnumerable<char>  names = "Tom Dick Harry Mary Jay";

foreach (char voewl in  "aeiou")
{
	 names = names.Where(c => c!=voewl);
}
foreach (var c in names)
	Console.Write(c);
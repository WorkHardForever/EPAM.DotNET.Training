<Query Kind="Statements" />

//string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
//
//
//var filtered= names.Where(n=>n.Contains ("a"));
//var sorted= filtered.OrderBy(n=>n);
//var query= sorted.Select(n=>n.ToUpper());
//
//query.Dump();//foreach

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
					from n in names
					let vowelless = n.Replace ("a", "").Replace ("e", "").Replace ("i", "")
									.Replace ("o", "").Replace ("u", "")
					where vowelless.Length > 2
					orderby vowelless
					select n;//Благодаря let переменная n по-прежнему находится
// в области видимости.
query.Dump();
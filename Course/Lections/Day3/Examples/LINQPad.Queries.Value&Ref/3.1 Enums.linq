<Query Kind="Program" />

enum Color : byte
{
	White,       // Assigned a value of 0
	Red,         // Assigned a value of 1
	Green,       // Assigned a value of 2
	Blue,        // Assigned a value of 3
	Orange,      // Assigned a value of 4
}

void Main()
{
	//Возможность получения в виде массива данные содержащие в перечислении
	Color[] colors = (Color[])Enum.GetValues(typeof(Color));
	Console.WriteLine("Number of symbols defined: " + colors.Length);
	Console.WriteLine("Value\tSymbol\n-----\t------");
	foreach (Color color in colors)
	{
		// Display each symbol in Decimal and General format.
		Console.WriteLine("{0,5:D}\t{0:G}", color);
	}	
		
	//Возвращает примитивный тип, используемый для хранения значения перечислимого типа
	Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));
}

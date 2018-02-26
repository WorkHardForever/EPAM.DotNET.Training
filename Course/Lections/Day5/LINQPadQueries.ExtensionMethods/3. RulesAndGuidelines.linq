<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

#region Rules and Guidelines
//1. Язык С# поддерживает только методы расширения, он не поддерживает
//свойств расширения, событий расширения, операторов расширения и т. д.

//2. Методы расширения ( методы со словом this перед первым аргументом )
//должны быть объявлены в статическом необобщенном классе.

//3. Компилятор С# ищет методы расширения, заданные только в статических
//классах, определенных в области файла

//4. Компилятору С# необходимо какое-то время для того, чтобы найти
//методы расширения; он просматривает все статические классы, определенные
//в области файла, и сканирует их статические методы

//5. Существует возможность определения в нескольких статических классах
//одинаковых методов расширения

//6. Существует потенциальная проблема с версиями
#endregion

void Main()
{
	// sb is null
	StringBuilder sb = null;
	// Calling extension method: NullReferenceException will NOT be thrown when calling IndexOf
	// NullReferenceException will be thrown inside IndexOf’s for loop
	sb.IndexOf('X');
	//Calling instance method: NullReferenceException WILL be thrown when calling Replace
	sb.Replace('.', '!');
}


public static class StringBuilderExtensions 
{
	public static int IndexOf(this StringBuilder sb, char value) 
	{
		for (int index = 0; index < sb.Length; index++)
			if (sb[index] == value) return index;
		return -1;
	}
}
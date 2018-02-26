<Query Kind="Program" />

// Type parameters can be introduced in the declaration of 
//classes, structs, interfaces, delegates and methods!!!


static void Swap<T> (ref T a, ref T b)
{
		T temp = a;
		a = b;
		b = temp;
}


//using CustomDictionary = System.Collections.Generic.Dictionary<int,string>;
struct Nullable<T>
{
	public T Value { get; set; }
}


// A generic type or method can have multiple parameters:
class Dictionary <TKey, TValue> { /*...*/ }

static void Main()
{
	// To instantiate:
	Dictionary<int,string> myDic = new Dictionary<int,string>();
	
	// Or:
	var myDicEasy = new Dictionary<int,string>();
}


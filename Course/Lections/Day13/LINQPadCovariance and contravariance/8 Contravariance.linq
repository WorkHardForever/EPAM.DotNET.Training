<Query Kind="Program" />

interface IMyComparer<in T> { int Compare(T a, T b); }

class ObjectComparer : IMyComparer<object> 
{
	public int Compare(object a, object b) 	
	{
		if(a.GetHashCode() > b.GetHashCode()) return 1;
		if(a.GetHashCode() < b.GetHashCode()) return -1;		
		return 0;
	}
}

void Main() 
{
	var result = new StringList();
	result.Sort().Dump();
	result.Sort(new ObjectComparer()).Dump();
}

class StringList
{
	string[] list = new[] { "One", "Two", "Three" };
	
	public IEnumerable<string> Sort(IMyComparer<string> comparer) 	
	{
		var innerList = new List<string>(list);		
		innerList.Sort(new ComparerAdapter<string>(comparer));		
		return innerList;
	}
	
	public IEnumerable<string> Sort() 	
	{
		var innerList = new List<string>(list);
		innerList.Sort();
		return list;
	}
	
	private class ComparerAdapter<T> : IComparer<T>
	{
		IMyComparer<T> innerComparer;
		
		public ComparerAdapter(IMyComparer<T> c)
		{
			innerComparer = c;
		}
		
		public int Compare(T a, T b)
		{
			return innerComparer.Compare(a, b);
		}
	}
}
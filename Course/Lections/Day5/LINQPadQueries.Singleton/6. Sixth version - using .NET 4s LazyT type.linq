<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

// Sixth version - using .NET 4's Lazy<T> type

public sealed class Singleton
{
	private static readonly Lazy<Singleton> lazy =
		new Lazy<Singleton>(() => new Singleton());
	
	public static Singleton Instance { get { return lazy.Value; } }

	private Singleton(){ }
}

void Main()
{
	Process.Start (@"C:\Program Files (x86)\Red Gate\.NET Reflector\Desktop 8.0\Reflector.exe", Assembly.GetExecutingAssembly().Location);
}
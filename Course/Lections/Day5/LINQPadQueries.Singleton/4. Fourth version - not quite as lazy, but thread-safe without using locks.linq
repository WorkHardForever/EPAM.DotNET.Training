<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

// Fourth version - not quite as lazy, but thread-safe without using locks

public sealed class Singleton
{
	private static readonly Singleton instance = new Singleton();

	// Explicit static constructor to tell C# compiler
	// not to mark type as beforefieldinit
	static Singleton() { }

	private Singleton(){ }

	public static Singleton Instance { get { return instance; } }
}

void Main(){ }
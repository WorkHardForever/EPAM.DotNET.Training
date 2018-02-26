<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

// First version - not thread-safe

// Bad code! Do not use!
public sealed class Singleton
{
	private static Singleton instance = null;

	private Singleton() { }

	public static Singleton Instance { get { return instance ?? new Singleton(); } }
}

void Main(){ }
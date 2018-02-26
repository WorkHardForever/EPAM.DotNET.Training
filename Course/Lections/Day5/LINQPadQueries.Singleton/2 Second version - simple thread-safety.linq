<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

// Second version - simple thread-safety

//Unfortunately, performance suffers as a lock is acquired every time the instance is requested
public sealed class Singleton
{
	private static Singleton instance = null;
	private static readonly object padlock = new object();

	private Singleton() { }

	public static Singleton Instance
	{
		get
		{
			lock (padlock)
			{
				return instance ?? new Singleton();
			}
		}
	}
}

void Main(){ }
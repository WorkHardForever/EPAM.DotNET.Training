<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
</Query>

void Main()
{
	#region Advanced
	http://habrahabr.ru/post/130318/
	#endregion
	// Third version - thread-safety using double-check locking
	
	public sealed class Singleton
	{
		private static volatile Singleton instance = null;
		#region volatile
		//Ключевое слово volatile указывает, что поле может быть изменено 
		//несколькими потоками, выполняющимися одновременно.
		//Поля, объявленные как volatile, не проходят оптимизацию компилятором,
		//которая предусматривает доступ посредством отдельного потока. 
		//Это гарантирует наличие наиболее актуального значения в поле в 
		//любое время.
		#endregion
		private static readonly object padlock = new object();
	
		Singleton() { }
	
		public static Singleton Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new Singleton();
						}
					}
				}
				return instance;
			}
		}
	}
	
	void Main(){ }
}

// Define other methods and classes here

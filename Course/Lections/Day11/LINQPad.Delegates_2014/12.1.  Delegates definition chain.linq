<Query Kind="Program" />

static class GetInvocationList
 {
    private delegate String GetStatus();

    public sealed class Light
    {
		public String SwitchPosition() 
		{  
		    return "The light is off"; 
		}
    }

    public sealed class Fan
    {
		public String Speed() 
		{
			throw new InvalidOperationException("The fan broke due to overheating"); 
		}
    }

    public sealed class Speaker
    {
		public String Volume() 
		{ 
			return "The volume is loud"; 
		}
    }

    public static void Go()
    {
		GetStatus getStatus =  delegate { return string.Empty; }; 
//		() => { return string.Empty; };
		
		Console.WriteLine(GetComponentStatusReport(getStatus));
     }

    private static string GetComponentStatusReport(GetStatus status)
    {
		status();
		
		var report = new StringBuilder();
		
		return report.ToString();
    }
}
 
void Main()
{
	GetInvocationList.Go();
}

// Define other methods and classes here
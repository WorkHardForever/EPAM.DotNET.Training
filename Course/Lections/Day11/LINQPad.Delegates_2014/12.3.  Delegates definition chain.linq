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
       GetStatus getStatus =  () => { return string.Empty; };
	   getStatus += new Light().SwitchPosition;
       getStatus += new Fan().Speed;
       getStatus += new Speaker().Volume;
       Console.WriteLine(GetComponentStatusReport(getStatus));
     }

   private static string GetComponentStatusReport(GetStatus status)
   {
     var report = new StringBuilder();

     Delegate[] arrayOfDelegates = status.GetInvocationList();

     foreach (GetStatus getStatus in arrayOfDelegates)
     {
         try
         {
             report.AppendFormat("{0}{1}{1}", getStatus(), Environment.NewLine);
         }
         catch (InvalidOperationException e)
         {
             Object component = getStatus.Target;//тип объекта
             report.AppendFormat(
                "Failed to get status from {1}{2}{0}   Error: {3}{0}{0}",
                Environment.NewLine,
                ((component == null) ? string.Empty : component.GetType() + "."),
                getStatus.Method.Name, e.Message);
         }
     }

     return report.ToString();
   }
}



void Main()
{
	GetInvocationList.Go();
}

// Define other methods and classes here

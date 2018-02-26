<Query Kind="Program" />

public class Logger
{
	//.......
    public void Log(string logText)
    {
        // сохранить лог в базе данных
    }
}


public class DatabaseLogger
{
	//.......
    public void Log(string logText)
    {
        // сохранить лог в базе данных
    }
}


public class SmtpMailer
{
	//private readonly Logger logger;
	private readonly DatabaseLogger logger;
	
	public SmtpMailer()
	{
	  //logger = new Logger();
	  logger = new DatabaseLogger();
	}
	
	 public void SendMessage(string message)
	 {
	         // отправить сообщение
	         logger.Log(message);
	}
}

void Main()
{
	
	
}

// Define other methods and classes here

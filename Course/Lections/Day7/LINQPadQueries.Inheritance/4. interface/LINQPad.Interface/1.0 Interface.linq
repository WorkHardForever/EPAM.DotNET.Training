<Query Kind="Program" />

public class Logger
{
	//.......
    public void Log(string logText)
    {
        // сохранить лог в базе данных
    }
}

public class SmtpMailer
{
	private readonly Logger logger;
	
	public SmtpMailer()
	{
	  logger = new Logger();
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

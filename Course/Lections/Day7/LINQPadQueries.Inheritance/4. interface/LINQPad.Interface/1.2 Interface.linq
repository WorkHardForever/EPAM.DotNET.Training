<Query Kind="Program" />

public interface ILogger
{
	void Log(string logText);
}
public class Logger:ILogger
{
	//.......
    public void Log(string logText)
    {
        // сохранить лог в базе данных
    }
}


public class DatabaseLogger:ILogger
{
	//.......
    public void Log(string logText)
    {
        // сохранить лог в базе данных
    }
}


public class SmtpMailer
{
    private readonly ILogger logger;

    public SmtpMailer(ILogger logger)
    {
        this.logger = logger;
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
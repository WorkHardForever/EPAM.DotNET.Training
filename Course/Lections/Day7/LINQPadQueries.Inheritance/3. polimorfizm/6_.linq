<Query Kind="Program" />

public class Employee
{
	public virtual void DoWork()
	{
       // ...
    }
}
public class Manager : Employee
{
	public override void DoWork()
	{
        // ...
       base.DoWork();
	}
}
void Main()
{
	Employee e = new Manager();
	e.DoWork();
}
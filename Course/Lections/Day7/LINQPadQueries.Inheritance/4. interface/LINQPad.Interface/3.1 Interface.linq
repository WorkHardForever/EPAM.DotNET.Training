<Query Kind="Program" />

public interface ICommonBird 
{
    void Eat();
}
public interface ISingingBird
{
    void Sing();
}
public interface IFlyingBird
{
    void Fly();
}
public class Nightingale: ICommonBird, ISingingBird, IFlyingBird
{
    // хм, ничего не изменилось
}
public class Pigeon : ICommonBird, IFlyingBird
{
    // о, так лучше, я могу не петь
}
public class Penguin : ICommonBird
{
    // так намного лучше! хотя я еще и плавать могу 
}
void Main()
{
}
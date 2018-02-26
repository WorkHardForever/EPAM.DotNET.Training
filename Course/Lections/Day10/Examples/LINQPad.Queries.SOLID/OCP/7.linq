<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Namespace>System.Windows.Shapes</Namespace>
</Query>

//Открытость иерархий типов относительна.
//Если вы ожидаете, что более вероятным является
//добавление нового типа, то следует использовать 
//классическую иерархию наследования. Если же иерархия
//типов стабильна, а все операции определяются клиентами, 
//то более подходящим будет подход на основе
//паттерна «Посетитель»

public enum ShapeType
{
	Circle,
	Square,
	Rectangle
}

public abstract class Shape
{
	public ShapeType ShapeType { get; set; }
	public abstract void Draw();

}

public class Circle : Shape
{
	public double Radius { get; set; }
	public override void Draw(){}
}

public class Square : Shape
{
	public double X { get; set; }
	public override void Draw(){}
}

public class Rectangle : Shape
{
	public double X { get; set; }
	public double Y { get; set; }
	public override void Draw(){}
}

public static void DrawShape(Shape shape)
{
	switch (shape.ShapeType)
	{
		case ShapeType.Circle:
			//DrawCircle((Circle)shape);
			break;
		case ShapeType.Square:
			//DrawSquare((Square)shape);
			break;
		case ShapeType.Rectangle:
			//DrawRectangle((Rectangle)shape);
			break;
		default:
			throw new InvalidOperationException("Неизвестный тип фигуры");
	}
}

//vs

public static void DrawShape(Shape shape)
{
	shape.Draw();
}
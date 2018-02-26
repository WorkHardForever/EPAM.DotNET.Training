using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        public interface IElement
        {
            string Text { get; set; }
            void Draw();
        }
        public class Element : IElement
        {
            public string Text { get; set; }

            public void Draw()
            {
                Console.WriteLine("Element text = {0}", this.Text);
            }
        }
        public class ElementDecoratorBase : IElement
        {
            protected readonly IElement _component;

            public ElementDecoratorBase(IElement component)
            {
                this._component = component;
            }

            public virtual string Text
            {
                get { return this._component.Text; }
                set { this._component.Text = value; }
            }

            public virtual void Draw()
            {
                this._component.Draw();
            }
        }
        public class ElementStrikedDecorator : ElementDecoratorBase
        {
            public ElementStrikedDecorator(IElement component) : base(component) { }

            public override void Draw()
            {
                this._component.Draw();
                this.Strike();
            }

            private void Strike()
            {
                Console.WriteLine("Striked");
            }
        }
        public class ElementBgndDecorator : ElementDecoratorBase
        {
            public Bitmap Background { get; set; }

            public ElementBgndDecorator(IElement component) : base(component) { }

            public override void Draw()
            {
                this.SetBackground();
                this._component.Draw();
            }

            private void SetBackground()
            {
                Console.WriteLine("Background");
            }
        }
        public static class DecoratorDemo
        {
            public static void DrawElement(IElement element)
            {
                element.Draw();
                Console.WriteLine("<--------------------------->");
            }

            public static void Execute()
            {
                var element = new Element
                {
                    Text = "Test1"
                };
                DecoratorDemo.DrawElement(element);


                var elementBgnd = new ElementBgndDecorator(element)
                {
                    Background = new Bitmap(10, 10), 
                    Text = "Text2"
                };
                DecoratorDemo.DrawElement(elementBgnd);

                var elementStriked = new ElementStrikedDecorator(elementBgnd)
                {
                    Text = "Test3"
                };

                DecoratorDemo.DrawElement(elementStriked);
            }
        }
        static void Main(string[] args)
        {
            DecoratorDemo.Execute();
            Console.ReadKey();
        }
    }
}

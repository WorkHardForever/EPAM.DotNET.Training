using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCollection
{
    class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("({0},{1})",this.X, this.Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BasicCollection<Point> bc = new BasicCollection<Point>();
            bc.FillList(new Point(1, 1), new Point(2, 2), new Point(3, 3));

            foreach (var word in bc)
            {
                Console.WriteLine(word);
                if (word.X == 3)
                {
                    bc.Delete(word);
                }          
            }

            Console.ReadLine();
        }
    }
}

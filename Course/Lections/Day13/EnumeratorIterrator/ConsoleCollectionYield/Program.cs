using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using CollectionYield;

namespace ConsoleCollectionYield
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point() { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("( {0}, {1} )", X, Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var collectionPoints = new CustomContainer<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) });
            Debug.WriteLine("====GetEnumerator===");
            foreach (var temp in collectionPoints)
            {
                //temp = new Point(4, 4);//CTE
                Debug.WriteLine(temp);
            }
            Debug.WriteLine("====ReverseEnumerator===");
            foreach (var temp in collectionPoints.Reverse)//foreach (var temp in arrayPoints.Reverse())
            {
                ////temp = new Point(4, 4);//CTE
                //temp.X = 4;
                //temp.Y = 4;
                Debug.WriteLine(temp);
            }
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PatternIterator
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
            var collection = new CustomContainer<string>(new[]
                {
                    "one", "two", "three", "four"
                });

           // CustomContainer<string>.CustomIterator iterator = collection.Iterator();
            Debug.WriteLine("Pattern iterator:");
            //while (iterator.MoveNext())
            //{
            //    Debug.WriteLine(iterator.Current);
            //}
            //iterator.Reset();
            Debug.WriteLine("foreach C#:");
            foreach (var temp in collection)
            {
                Debug.WriteLine(temp);
            }

            //массив изменился
            collection[0] = "zero";
            //Debug.WriteLine("=================");
            //iterator = collection.Iterator();
            //Debug.WriteLine("Pattern iterator:");
            //while (iterator.MoveNext())
            //{
            //    Debug.WriteLine(iterator.Current);
            //}
            //iterator.Reset();
            //Debug.WriteLine("foreach C#:");
            //foreach (var temp in collection)
            //{
            //    Debug.WriteLine(temp);
            //}

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

using System;

namespace Task2Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class ComputeAreaVisitor : IShapeVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        public double Area { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="circle"></param>
        public void Visit(Circle circle)
        {
            Area = Math.PI * Math.Sqrt(circle.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="square"></param>
        public void Visit(Square square)
        {
            Area = Math.Sqrt(square.X);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        public void Visit(Rectangle rectangle)
        {
            Area = rectangle.X * rectangle.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        public void Visit(Triangle rectangle)
        {
            var p = (int)(rectangle.X + rectangle.Y + rectangle.Z) / 2;
            Area = Math.Sqrt(p * (p - rectangle.X) * (p - rectangle.Y) * (p - rectangle.Z));
        }
    }
}

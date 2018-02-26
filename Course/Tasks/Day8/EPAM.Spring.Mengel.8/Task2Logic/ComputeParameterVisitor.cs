using System;

namespace Task2Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class ComputeParameterVisitor : IShapeVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        public double Parameter { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="circle"></param>
        public void Visit(Circle circle)
        {
            Parameter = 2 * Math.PI * circle.Radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="square"></param>
        public void Visit(Square square)
        {
            Parameter = 2 * square.X;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        public void Visit(Rectangle rectangle)
        {
            Parameter = rectangle.X + rectangle.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        public void Visit(Triangle rectangle)
        {
            Parameter = rectangle.X + rectangle.Y + rectangle.Z;
        }
    }
}
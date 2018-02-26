namespace Task2Logic
{
    /// <summary>
    /// 
    /// </summary>
    public static class ShapeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static double GetArea(this Shape shape)
        {
            var visitor = new ComputeAreaVisitor();
            shape.Accept(visitor);
            return visitor.Area;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static double GetParameter(this Shape shape)
        {
            var visitor = new ComputeParameterVisitor();
            shape.Accept(visitor);
            return visitor.Parameter;
        }
    }
}

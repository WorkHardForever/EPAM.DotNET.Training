namespace Task2Logic
{
    /// <summary>
    /// 
    /// </summary>
    public interface IShapeVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="circle"></param>
        void Visit(Circle circle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="square"></param>
        void Visit(Square square);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        void Visit(Rectangle rectangle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        void Visit(Triangle rectangle);
    }
}
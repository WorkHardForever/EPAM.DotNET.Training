namespace Task2Logic
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit((dynamic)this);
        }
    }
}

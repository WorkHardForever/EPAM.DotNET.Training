using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_DEMO
{
    /// <summary>
    /// Class describing a triangle on three sides
    /// </summary>
    public class TriangleXML
    {
        #region Fildes
        /// <summary>
        /// side a 
        /// </summary>
        private double a;
        /// <summary>
        /// sade b
        /// </summary>
        private double b;
        /// <summary>
        /// side c
        /// </summary>
        private double c;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="a">side a </param>
        /// <param name="b">side b </param>
        /// <param name="c">side c </param>
        public TriangleXML(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Determination of the area of a triangle using the formula of Heron
        /// </summary>
        /// <returns>area of ​​a triangle</returns>
        public double GetArea()
        {
            return a*b*c;
        }
        #endregion
    }
}

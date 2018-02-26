using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3Logic;

namespace Task3LogicTests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructors_ArgumentNullException_Test()
        {
            var polynomial = new Polynomial((double[])null);
        }

        [TestMethod]
        public void CalculatePolynomial_IfValueIs4_CoeffArrayIs1and2and3_57Returned()
        {
            var polynomial = new Polynomial(new double[] { 1, 2, 3 });
            var value = 4;
            var expected = 57;

            Assert.AreEqual(expected, polynomial.CalculatePolynomial(value));
        }

        [TestMethod]
        public void AddWithMonomial_CoeffArrayIs1and2and3and4and5_CoefficientIs9_DegreeIs3_1and2and3and13and5Returned()
        {
            var polynomial = new Polynomial(new double[] { 1, 2, 3, 4, 5 });
            var coefficient = 9;
            var degree = 3;
            var expected = new Polynomial(new double[] { 1, 2, 3, 13, 5 });

            Assert.AreEqual(expected, polynomial.AddWithMonomial(coefficient, degree));
        }

        [TestMethod]
        public void Add_FirstCoeffArrayIs1and2and3and13and5_SecondCoeffArrayIs1and3and5and7and9_2and5and8and11and14Returned()
        {
            var polynomial1 = new Polynomial(new double[] { 1, 2, 3, 4, 5 });
            var polynomial2 = new Polynomial(new double[] { 1, 3, 5, 7, 9 });
            var expected = new Polynomial(new double[] { 2, 5, 8, 11, 14 });

            Assert.AreEqual(expected, polynomial1 + polynomial2);
        }

        [TestMethod]
        public void Sub_FirstCoeffArrayIsNeg1and2andNeg3_SecondCoeffArrayIs5andNeg5_Neg5and15andNeg25and15Returned()
        {
            var polynomial1 = new Polynomial(new double[] { 1, 2, 3, 4, 5 });
            var polynomial2 = new Polynomial(new double[] { 1, 3, 5, 7, 9 });
            var expected = new Polynomial(new double[] { 0, -1, -2, -3, -4 });

            Assert.AreEqual(expected, polynomial1 - polynomial2);
        }

        [TestMethod]
        public void MultiplyWithMonomial_CoeffArrayIs1and2and3and4and5_CoefficientIs9_DegreeIs3_0and0and0and9and18and27and36and45Returned()
        {
            var polynomial = new Polynomial(new double[] { 1, 2, 3, 4, 5 });
            var coefficient = 9;
            var degree = 3;
            var expected = new Polynomial(new double[] { 0, 0, 0, 9, 18, 27, 36, 45 });

            Assert.AreEqual(expected, polynomial.MultiplyWithMonomial(coefficient, degree));
        }

        [TestMethod]
        public void Multiply_FirstCoeffArrayIsNeg1and2andNeg3_SecondCoeffArrayIs5andNeg5_Neg5and15andNeg25and15Returned()
        {
            var polynomial1 = new Polynomial(new double[] { -1, 2, -3 });
            var polynomial2 = new Polynomial(new double[] { 5, -5 });
            var expected = new Polynomial(new double[] { -5, 15, -25, 15 });

            Assert.AreEqual(expected, polynomial1 * polynomial2);
        }

        [TestMethod]
        public void Equals_FirstCoeffArrayIs2and4and6and8and10_SecondCoeffArrayIs2and4and6and8and12_TrueReturned()
        {
            var polynomial1 = new Polynomial(new double[] { 2, 4, 6, 8, 10 });
            var polynomial2 = new Polynomial(new double[] { 2, 4, 6, 8, 12 });
            var expected = false;

            Assert.AreEqual(expected, polynomial1.Equals(polynomial2));
        }

        [TestMethod]
        public void Op_Equality_FirstCoeffArrayIs2and4and6and8and10_SecondCoeffArrayIs2and4and6and8and12_FalseReturned()
        {
            var polynomial1 = new Polynomial(new double[] { 2, 4, 6, 8, 10 });
            var polynomial2 = new Polynomial(new double[] { 2, 4, 6, 8, 12 });
            var expected = false;

            Assert.AreEqual(expected, polynomial1 == polynomial2);
        }

        [TestMethod]
        public void ToString_CoeffArrayIs1and2and3and4_4mulXpow3plus3mulXpow2plus2mulXpow1Returned()
        {
            var polynomial = new Polynomial(new double[] { 1, 2, 3, 4 });
            var expected = "4 * (x ^ 3) + 3 * (x ^ 2) + 2 * (x ^ 1) + 1";

            Assert.AreEqual(expected, polynomial.ToString());
        }
    }
}

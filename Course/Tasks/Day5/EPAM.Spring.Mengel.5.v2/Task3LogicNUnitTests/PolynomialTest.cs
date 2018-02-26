using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task3Logic;

namespace Task3LogicNUnitTests
{
    [TestFixture]
    public class PolynomialTest
    {
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        public void Constructors_Exceptions_Test(double[] array)
        {
            var polynomial = new Polynomial(array);
        }

        public IEnumerable<TestCaseData> CalculateData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3 }), 4).Returns(57);
                yield return new TestCaseData(new Polynomial(new double[] { 0, 2, 4 }), 6).Returns(156);
            }
        }
        [Test, TestCaseSource(nameof(CalculateData))]
        public double CalculatePolynomial_Test(Polynomial polynomial, double value)
        {
            return polynomial.CalculatePolynomial(value);
        }

        public IEnumerable<TestCaseData> AddWithMonomialData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), 5, 6).Returns(new Polynomial(new double[] { 1, 2, 3, 4, 5, 0, 5 }));
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), 9, 3).Returns(new Polynomial(new double[] { 1, 2, 3, 13, 5 }));
            }
        }
        [Test, TestCaseSource(nameof(AddWithMonomialData))]
        public Polynomial AddWithMonomial_Test(Polynomial polynomial, int coefficient, int degree) =>
            polynomial.AddWithMonomial(coefficient, degree);

        public IEnumerable<TestCaseData> AddData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), new Polynomial(new double[] { 5, 4, 3, 2, 1 })).Returns(new Polynomial(new double[] { 6, 6, 6, 6, 6 }));
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), new Polynomial(new double[] { 1, 3, 5, 7, 9 })).Returns(new Polynomial(new double[] { 2, 5, 8, 11, 14 }));
            }
        }
        [Test, TestCaseSource(nameof(AddData))]
        public Polynomial Add_Test(Polynomial polynomial1, Polynomial polynomial2) =>
            polynomial1 + polynomial2;

        public IEnumerable<TestCaseData> SubtractionData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), new Polynomial(new double[] { 1, 2, 3, 4, 5 })).Returns(new Polynomial(new double[] { }));
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), new Polynomial(new double[] { 1, 3, 5, 7, 9 })).Returns(new Polynomial(new double[] { 0, -1, -2, -3, -4 }));
            }
        }
        [Test, TestCaseSource(nameof(SubtractionData))]
        public Polynomial Subtraction_Test(Polynomial polynomial1, Polynomial polynomial2) =>
            polynomial1 - polynomial2;

        public IEnumerable<TestCaseData> MultiplyWithMonomialData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), 5, 1).Returns(new Polynomial(new double[] { 0, 5, 10, 15, 20, 25 }));
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), 9, 3).Returns(new Polynomial(new double[] { 0, 0, 0, 9, 18, 27, 36, 45 }));
            }
        }
        [Test, TestCaseSource(nameof(MultiplyWithMonomialData))]
        public Polynomial MultiplyWithMonomial_Test(Polynomial polynomial, int coefficient, int degree) =>
            polynomial.MultiplyWithMonomial(coefficient, degree);

        public IEnumerable<TestCaseData> MultiplyData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 10, 9, 8 }), new Polynomial(new double[] { 3, 4, 5 })).Returns(new Polynomial(new double[] { 30, 67, 110, 77, 40 }));
                yield return new TestCaseData(new Polynomial(new double[] { -1, 2, -3 }), new Polynomial(new double[] { 5, -5 })).Returns(new Polynomial(new double[] { -5, 15, -25, 15 }));
            }
        }
        [Test, TestCaseSource(nameof(MultiplyData))]
        public Polynomial Multiply_Test(Polynomial polynomial1, Polynomial polynomial2) =>
            polynomial1 * polynomial2;

        public IEnumerable<TestCaseData> EqualsTestData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), null).Returns(false);
                yield return new TestCaseData(new Polynomial(new double[] { 1, 3, 5, 7, 9 }), new Polynomial(new double[] { 1, 3, 5, 7, 9 })).Returns(true);
                yield return new TestCaseData(new Polynomial(new double[] { 2, 4, 6, 8, 10 }), new Polynomial(new double[] { 2, 4, 6, 8, 12 })).Returns(false);
            }
        }
        [Test, TestCaseSource(nameof(EqualsTestData))]
        public bool Equals_Test(Polynomial polynomial1, Polynomial polynomial2) =>
            polynomial1.Equals(polynomial2);

        public IEnumerable<TestCaseData> Op_EqualityData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 }), null).Returns(false);
                yield return new TestCaseData(new Polynomial(new double[] { 1, 3, 5, 7, 9 }), new Polynomial(new double[] { 1, 3, 5, 7, 9 })).Returns(true);
                yield return new TestCaseData(new Polynomial(new double[] { 2, 4, 6, 8, 10 }), new Polynomial(new double[] { 2, 4, 6, 8, 12 })).Returns(false);
            }
        }
        [Test, TestCaseSource(nameof(Op_EqualityData))]
        public bool Op_Equality_Test(Polynomial polynomial1, Polynomial polynomial2) =>
            polynomial1 == polynomial2;

        [TestCase(new double[] { 1, 0, 0, 0, 0 }, Result = "1")]
        [TestCase(new double[] { 0, 1, 0, 0, 0 }, Result = "1 * (x ^ 1)")]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, Result = "5 * (x ^ 4) + 4 * (x ^ 3) + 3 * (x ^ 2) + 2 * (x ^ 1) + 1")]
        public string ToString_Test(double[] coefficientArray)
        {
            var polynomial = new Polynomial(coefficientArray);

            return polynomial.ToString();
        }

        [TestCase(new double[] { 1, 0, 0, 0, 0 }, Result = "1")]
        [TestCase(new double[] { 0, 1, 0, 0, 0 }, Result = "1 * (x ^ 1)")]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, Result = "5 * (x ^ 4) + 4 * (x ^ 3) + 3 * (x ^ 2) + 2 * (x ^ 1) + 1")]
        public string Op_Implicit_Test(double[] array)
        {
            Polynomial polynomial = array;

            return polynomial.ToString();
        }

        public IEnumerable<TestCaseData> Op_Explicit
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { 1, 0, 0, 0, 0 })).Returns("1");
                yield return new TestCaseData(new Polynomial(new double[] { 0, 1, 0, 0, 0 })).Returns("1 * (x ^ 1)");
                yield return new TestCaseData(new Polynomial(new double[] { 1, 2, 3, 4, 5 })).Returns("5 * (x ^ 4) + 4 * (x ^ 3) + 3 * (x ^ 2) + 2 * (x ^ 1) + 1");
            }
        }
        [Test, TestCaseSource(nameof(Op_Explicit))]
        public string Op_Explicit_Test(Polynomial polynomial)
        {
            double[] a = (double[])polynomial;

            return polynomial.ToString();
        }
    }
}

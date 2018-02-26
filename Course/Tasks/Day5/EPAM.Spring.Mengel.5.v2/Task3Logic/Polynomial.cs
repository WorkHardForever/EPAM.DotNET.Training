using System;
using System.Collections;
using System.Linq;
using System.Text;
using static System.Math;
using static System.Array;

namespace Task3Logic
{
    /// <summary>
    /// Polinomial class with main methods
    /// </summary>
    public class Polynomial : IEquatable<Polynomial>, IFormattable
    {
        #region Private Readonly Fields

        /// <summary>
        /// Minimum value checking by epselon
        /// </summary>
        private static readonly double EPS = .0000001;

        /// <summary>
        /// Main array of single polynomial
        /// </summary>
        private readonly double[] _coefficientArray;

        #endregion

        #region Constructor

        /// <summary>
        /// Create new Polynomial by coefficients
        /// </summary>
        /// <param name="coefficientArray"></param>
        public Polynomial(double[] coefficientArray)
        {
            if (coefficientArray == null)
                throw new ArgumentNullException(nameof(coefficientArray));

            _coefficientArray = GetCoefficientArrayByNormalizing(coefficientArray);
        }

        #endregion

        #region Private Property

        /// <summary>
        /// Max degree of x-value
        /// </summary>
        private int Degree { get { return _coefficientArray.Length - 1; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Find result of polynomial by writen x = 'value'
        /// </summary>
        /// <param name="value">X of polynomial</param>
        /// <returns>Decidions of polynomial</returns>
        public double CalculatePolynomial(double value)
        {
            var result = .0;
            for (int i = 0; i <= Degree; i++)
                result += Pow(value, i) * _coefficientArray[i];

            return result;
        }

        /// <summary>
        /// Add monomial to polynomial
        /// </summary>
        /// <param name="coefficient">Coefficient of monomial</param>
        /// <param name="degree">Degree of monomial</param>
        /// <returns>The sum with monomial</returns>
        public Polynomial AddWithMonomial(double coefficient, int degree)
        {
            var resultCoefficientArray = new double[Max(Degree, degree) + 1];

            if (Degree < degree)
            {
                for (int i = 0; i <= Degree; i++)
                    resultCoefficientArray[i] = _coefficientArray[i];
                for (int i = Degree + 1; i < degree; i++)
                    resultCoefficientArray[i] = 0;

                resultCoefficientArray[degree] = coefficient;
            }
            else
            {
                for (int i = 0; i <= Degree; i++)
                {
                    resultCoefficientArray[i] = _coefficientArray[i];
                    if (degree == i)
                        resultCoefficientArray[i] += coefficient;
                }
            }

            return new Polynomial(resultCoefficientArray);
        }

        /// <summary>
        /// Polynomial multiplication with monopial
        /// </summary>
        /// <param name="coefficient">Coefficient of monomial</param>
        /// <param name="degree">Degree of monomial</param>
        /// <returns>The multiplication with monomial</returns>
        public Polynomial MultiplyWithMonomial(double coefficient, int degree)
        {
            var sumDegrees = Degree + degree;
            var tempArray = new double[sumDegrees + 1];

            for (int i = 0; i <= sumDegrees; i++)
                tempArray[i] = degree > i ? 0 : _coefficientArray[i - degree] * coefficient;

            return new Polynomial(tempArray);
        }

        #endregion

        #region Overrides

        #region Operators

        /// <summary>
        /// Get equal if coefficient arrays are equals
        /// </summary>
        /// <param name="polynomial1">First polynomial</param>
        /// <param name="polynomial2">Second polynomial</param>
        /// <returns>Equal result</returns>
        public static bool operator ==(Polynomial polynomial1, Polynomial polynomial2) =>
            CheckDeferentReferences(polynomial1, polynomial2) ??
            EqualsCoefficientArrays(polynomial1._coefficientArray, polynomial2._coefficientArray);

        /// <summary>
        /// Get if not equals coefficient arrays
        /// </summary>
        /// <param name="polynomial1">First polynomial</param>
        /// <param name="polynomial2">Second polynomial</param>
        /// <returns>Unequal result</returns>
        public static bool operator !=(Polynomial polynomial1, Polynomial polynomial2) =>
            !(polynomial1 == polynomial2);

        /// <summary>
        /// Add polinomuals
        /// </summary>
        /// <param name="polynomial1">First polynomial</param>
        /// <param name="polynomial2">Second polynomial</param>
        /// <returns>Sum result</returns>
        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2) =>
            Add(polynomial1, polynomial2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polynomial"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException(nameof(polynomial));
            }

            var inversionCoefficientArray = new double[polynomial.Degree + 1];
            for (int i = 0; i <= polynomial.Degree; i++)
                inversionCoefficientArray[i] = (-1) * polynomial._coefficientArray[i];

            return new Polynomial(inversionCoefficientArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2) =>
            Subtraction(polynomial1, polynomial2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2) =>
            Multiply(polynomial1, polynomial2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public static implicit operator Polynomial(double[] other)
        {
            if (other == null)
                throw new NullReferenceException();

            return new Polynomial(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public static explicit operator double[](Polynomial other)
        {
            if (other == null)
                throw new NullReferenceException();

            return other._coefficientArray;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format = null, IFormatProvider formatProvider = null)
        {
            var result = new StringBuilder();

            for (int i = Degree; i >= 0; i--)
            {
                if (EPS >= Abs(_coefficientArray[i]))
                    continue;

                if (i != _coefficientArray.Length - 1)
                    result.Append(" + ");

                result.Append(_coefficientArray[i]);

                if (i != 0)
                    result.Append($" * (x ^ {i})");
            }

            return result.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) =>
            CheckReferences(obj) ??
            (obj.GetType() == GetType()) && (EqualsCoefficientArrays(
                _coefficientArray,
                ((Polynomial)obj)._coefficientArray)
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Polynomial obj) =>
            CheckReferences(obj) ?? EqualsCoefficientArrays(_coefficientArray, obj._coefficientArray);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return _coefficientArray.Aggregate(17, (current, item) => current * 23 + item.GetHashCode());
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Sum polynomials 
        /// </summary>
        /// <param name="polynomial1">First polynomial</param>
        /// <param name="polynomial2">Second polynomial</param>
        /// <returns>The sum of polynomials</returns>
        public static Polynomial Add(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null)
                throw new ArgumentNullException(nameof(polynomial1));

            if (polynomial2 == null)
                throw new ArgumentNullException(nameof(polynomial2));

            var newDegree = Max(polynomial1.Degree, polynomial2.Degree);
            var resultCoefficientArray = new double[newDegree + 1];

            for (int i = 0; i <= newDegree; i++)
            {
                var sumMonomialCoefficient = .0;

                if (i <= polynomial1.Degree)
                    sumMonomialCoefficient += polynomial1._coefficientArray[i];
                if (i <= polynomial2.Degree)
                    sumMonomialCoefficient += polynomial2._coefficientArray[i];

                resultCoefficientArray[i] = sumMonomialCoefficient;
            }

            return new Polynomial(resultCoefficientArray);
        }

        /// <summary>
        /// Sub polynomials
        /// </summary>
        /// <param name="polynomial1">First polynomial</param>
        /// <param name="polynomial2">Second polynomial</param>
        /// <returns>The sub of polynomials</returns>
        public static Polynomial Subtraction(Polynomial polynomial1, Polynomial polynomial2) =>
            polynomial1 + (-polynomial2);

        /// <summary>
        /// Polynomials multiplication
        /// </summary>
        /// <param name="polynomial1">First polynomial</param>
        /// <param name="polynomial2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        public static Polynomial Multiply(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null)
            {
                throw new ArgumentNullException(nameof(polynomial1));
            }
            if (polynomial2 == null)
            {
                throw new ArgumentNullException(nameof(polynomial2));
            }

            var result = new Polynomial(new double[0]);

            for (int i = 0; i <= polynomial1.Degree; i++)
                result += polynomial2.MultiplyWithMonomial(polynomial1._coefficientArray[i], i);

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Getting normalizing coefficient array 
        /// </summary>
        /// <param name="coefficientArray">Array for normalize</param>
        /// <returns>Normalized array</returns>
        private double[] GetCoefficientArrayByNormalizing(double[] coefficientArray)
        {
            var normalizedArray = NormalizeCoefficientArray(coefficientArray);
            return normalizedArray.Length != 0 ? normalizedArray : new[] { .0 };
        }

        /// <summary>
        /// Getting normalizing coefficient array 
        /// </summary>
        /// <param name="array">Array for normalize</param>
        /// <returns>Normalized array</returns>
        private double[] NormalizeCoefficientArray(double[] array)
        {
            var newLength = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (EPS < Abs(array[i]))
                {
                    newLength = i + 1;
                    break;
                }
            }

            var normalizedArray = new double[newLength];
            Copy(array, normalizedArray, newLength);
            return normalizedArray;
        }

        /// <summary>
        /// Check equal reference of Polynomials
        /// </summary>
        /// <param name="obj">Some Polynomial</param>
        /// <returns>If equal get true, if one of them null, so getting false, but if not understanding - null</returns>
        private bool? CheckReferences(object obj) =>
            CheckDeferentReferences(this, obj);

        #endregion

        #region Private Static Methods

        private static bool EqualsCoefficientArrays(double[] array1, double[] array2) =>
            ((IStructuralEquatable)array1).Equals(array2, StructuralComparisons.StructuralEqualityComparer);

        private static bool? CheckDeferentReferences(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;

            if (ReferenceEquals(obj1, obj2))
                return true;

            return null;
        }

        #endregion
    }
}

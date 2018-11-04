using System;
using System.Text;

namespace Polynomial
{
    /// <summary>
    /// class polynomial
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class
        /// </summary>
        /// <param name="coeffs">given coefficients</param>
        public Polynomial(double[] coeffs)
        {
            Coefficients = CheckPolynomValues(coeffs);
        }

        /// <summary>
        /// polynomial coefficients
        /// </summary>
        public double[] Coefficients { get; set; }

        /// <summary>
        /// method to get coefficient connected to power
        /// </summary>
        /// <param name="factor">given power</param>
        /// <returns>appropriate coefficient</returns>
        public double this[int factor]
        {
            get
            {
                if (factor < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (factor >= Coefficients.Length)
                {
                    return 0;
                }

                return Coefficients[factor];
            }
        }

        /// <summary>
        /// overloaded operator +
        /// </summary>
        /// <param name="first">one polynomial</param>
        /// <param name="second">another polynomial</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int minLength = first.Coefficients.Length < second.Coefficients.Length ?
                first.Coefficients.Length : second.Coefficients.Length;
            int maxLength = first.Coefficients.Length >= second.Coefficients.Length ?
                first.Coefficients.Length : second.Coefficients.Length;

            double[] resultCoefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++)
            {
                resultCoefficients[i] = first[i] + second[i];
            }

            if (first.Coefficients.Length > second.Coefficients.Length)
            {
                Array.Copy(
                    first.Coefficients, 
                    minLength, 
                    resultCoefficients,
                    minLength, 
                    maxLength - minLength);
            }
            else
            {
                Array.Copy(
                    second.Coefficients,
                    minLength, 
                    resultCoefficients,
                    minLength, 
                    maxLength - minLength);
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// overloaded operator -
        /// </summary>
        /// <param name="first">one polynomial</param>
        /// <param name="second">another polynomial</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            double[] negativeSecondPolynomCoefficients = new double[second.Coefficients.Length];
            int i = 0;

            foreach (double val in second.Coefficients)
            {
                negativeSecondPolynomCoefficients[i] = -second.Coefficients[i];
                i++;
            }

            return first + new Polynomial(negativeSecondPolynomCoefficients);
        }

        /// <summary>
        /// overloaded polynomial * integer
        /// </summary>
        /// <param name="polinomial">given polynomial</param>
        /// <param name="multiplier">given multiplier</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator *(Polynomial polinomial, int multiplier)
        {
            double[] resultCoefficients = new double[polinomial.Coefficients.Length];

            for (int i = 0; i < polinomial.Coefficients.Length; i++)
            {
                resultCoefficients[i] = polinomial[i] * multiplier;
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// overloaded integer * polynomial
        /// </summary>
        /// <param name="multiplier">given multiplier</param>
        /// <param name="polinomial">given polynomial</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator *(int multiplier, Polynomial polinomial)
        {
            return polinomial * multiplier;
        }

        /// <summary>
        /// overloaded polynomial * polynomial
        /// </summary>
        /// <param name="first">first polynomial</param>
        /// <param name="second">second polynomial</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int resultLength = first.Coefficients.Length + second.Coefficients.Length;

            double[] resultCoefficients = new double[resultLength];

            for (int i = 0; i < first.Coefficients.Length; i++)
            {
                for (int j = 0; j < second.Coefficients.Length; j++)
                {
                    resultCoefficients[i + j] += first[i] * first[j];
                }
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// overloaded polynomial / integer
        /// </summary>
        /// <param name="polinomial">given polynomial</param>
        /// <param name="devider">given integer</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator /(Polynomial polinomial, int devider)
        {
            double[] resultCoefficients = new double[polinomial.Coefficients.Length];

            for (int i = 0; i < polinomial.Coefficients.Length; i++)
            {
                resultCoefficients[i] = polinomial.Coefficients[i] / devider;
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// overloaded ==
        /// </summary>
        /// <param name="first">first polynomial</param>
        /// <param name="second">second polynomial</param>
        /// <returns>true if equals</returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first.Coefficients.Length != second.Coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < first.Coefficients.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// overloaded !=
        /// </summary>
        /// <param name="first">first polynomial</param>
        /// <param name="second">second polynomial</param>
        /// <returns>true if equals</returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }

        /// <summary>
        /// overridden method ToString
        /// </summary>
        /// <returns>polynomial to string value</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (i == 0 && Coefficients[i] != 0.0)
                {
                    str.AppendFormat($"{Coefficients[i]}");
                }
                else
                {
                    if (Coefficients[i] != 0.0)
                    {
                        if (str.Length > 0)
                        {
                            str.AppendFormat($" + {Coefficients[i]}*x^{i}");
                        }
                        else
                        {
                            str.AppendFormat($"{Coefficients[i]}*x^{i}");
                        }
                    }
                }
            }

            if (str.Length == 0)
            {
                return "0";
            }

            return str.ToString();
        }

        /// <summary>
        /// overridden method GetHashCode
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                hash += Coefficients[i].GetHashCode() + i.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// overridden method Equals
        /// </summary>
        /// <param name="obj">compared object</param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
        {
            Polynomial p = obj as Polynomial;

            if (p?.Coefficients.Length != Coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i <= Coefficients.Length; i++)
            {
                if (Math.Abs(this[i] - p[i]) > double.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// check given double values
        /// </summary>
        /// <param name="values">doubles for check</param>
        /// <returns>return if values are correct</returns>
        private double[] CheckPolynomValues(double[] values)
        {
            double[] checkedValues = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (double.IsNaN(values[i]) || double.IsInfinity(values[i]))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    checkedValues[i] = values[i];
                }
            }

            return checkedValues;
        }
    }
}

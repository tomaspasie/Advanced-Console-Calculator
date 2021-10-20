using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject
{
    class Operations
    {
        public static Func<double, double, double> Addition = (a, b) => a + b;
        public static Func<double, double, double> Subtraction = (a, b) => a - b;
        public static Func<double, double, double> Multiplication = (a, b) => a * b;
        public static Func<double, double, double> Division = Divide;
        public static Func<double, double, double> SquareRoot = (a,b) => Math.Sqrt(a);
        public static Func<double, double, double> Square = (a,b) => a * a;

        public static double Divide(double a, double b)
        {
            double result;

            while (b == 0)
            {
                result = 0;
                return result;
            }

            result = a / b;

            return result;
        }
    }
}

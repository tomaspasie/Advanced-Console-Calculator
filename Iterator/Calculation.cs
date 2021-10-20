using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.Iterator
{
    // Collection Item (Iterator Design Pattern)
    class Calculation
    {
        public double A { get; set; }
        public double B { get; set; }
        public Func<double, double, double> Operation { get; set; }

        public Calculation() { }

        // Handles Addition, Subtraction, Multiplication, Division, Square Root, and Square  Calculations
        public Calculation(double a, double b, Func<double, double, double> operation)
        {
            A = a;
            B = b;
            Operation = operation;
        }

        public static Calculation Create(double a, double b, Func<double, double, double> operation, ICalculatorComponent calculator)
        {
            var _calculation = new Calculation(a, b, operation);
            calculator.CalculationHistory.Add(_calculation);

            return _calculation;
        }

    }
}

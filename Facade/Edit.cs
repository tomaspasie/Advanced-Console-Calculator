using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CalculatorProject.Iterator;

namespace CalculatorProject.Facade
{
    // Subsystem ClassA (Facade Design Pattern)
    class Edit
    {

        public Calculation TwoVariables(Calculation calculation, double c, double d, string operation)
        {
            calculation.A = c;
            calculation.B = d;

            bool end1 = operation.Equals("addition");
            bool end2 = operation.Equals("subtraction");
            bool end3 = operation.Equals("multiplication");
            bool end4 = operation.Equals("division");

            while (end1)
            {
                calculation.Operation = Operations.Addition;
                end1 = false;
            }

            while (end2)
            {
                calculation.Operation = Operations.Subtraction;
                end2 = false;
            }

            while (end3)
            {
                calculation.Operation = Operations.Multiplication;
                end3 = false;
            }

            while (end4)
            {
                calculation.Operation = Operations.Division;
                end4 = false;
            }

            return calculation;
        }

        public Calculation OneVariable(Calculation calculation, double c, string operation)
        {
            calculation.A = c;
            calculation.B = 0;

            bool end5 = operation.Equals("square root");
            bool end6 = operation.Equals("square");

            while (end5)
            {
                calculation.Operation = Operations.SquareRoot;
                end5 = false;
            }

            while (end6)
            {
                calculation.Operation = Operations.Square;
                end6 = false;
            }

            return calculation;
        }
    }
}

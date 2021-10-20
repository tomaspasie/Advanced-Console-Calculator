using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Events;
using CalculatorProject.Iterator;

namespace CalculatorProject.Facade
{
    // The Facade Class (Facade Design Pattern)
    class CalculationManipulation
    {
        public Edit _edit = new Edit();
        public Remove _remove = new Remove();

        public void RemoveCalculation(ICalculatorComponent calculator, int index)
        {
            _remove.Execute(calculator, index);
        }

        public Calculation EditCalculation(String operation, Calculation calculation, ICalculatorComponent calculator, Iterator.Iterator iterator)
        {
            bool end1 = operation.Equals("addition");
            bool end2 = operation.Equals("subtraction");
            bool end3 = operation.Equals("multiplication");
            bool end4 = operation.Equals("division");
            bool end5 = operation.Equals("square root");
            bool end6 = operation.Equals("square");

            while (end1)
            {
                Prompts._FirstNumber();
                double a = Convert.ToDouble(Console.ReadLine());
                Prompts._SecondNumber();
                double b = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "+");

                end1 = false;
            }

            while (end2)
            {
                Prompts._FirstNumber();
                double a = Convert.ToDouble(Console.ReadLine());
                Prompts._SecondNumber();
                double b = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "-");

                end2 = false;
            }

            while (end3)
            {
                Prompts._FirstNumber();
                double a = Convert.ToDouble(Console.ReadLine());
                Prompts._SecondNumber();
                double b = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "*");

                end3 = false;
            }

            while (end4)
            {
                Prompts._FirstNumber();
                double a = Convert.ToDouble(Console.ReadLine());
                double b = 0;
                bool c = true;

                while (c)
                {
                    Prompts._SecondNumber();
                    b = Convert.ToDouble(Console.ReadLine());

                    while (b == 0)
                    {
                        Prompts.Zero();
                        b = Convert.ToDouble(Console.ReadLine());
                    }

                    c = false;
                }

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "/");

                end4 = false;
            }

            while (end5)
            {
                Prompts._Number();
                double a = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.OneVariable(calculation, a, operation);
                iterator.SetOneVariableCalculation(calculator, calculation, "SQUARE ROOT OF");

                end5 = false;
            }

            while (end6)
            {
                Prompts._Number();
                double a = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.OneVariable(calculation, a, operation);
                iterator.SetOneVariableCalculation(calculator, calculation, "SQUARE OF");

                end6 = false;
            }

            return calculation;
        }

    }
}

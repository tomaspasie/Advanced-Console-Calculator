using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.State;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace CalculatorProject.Iterator
{
    // Concrete Iterator Class (Iterator Design Pattern)
    class Iterator : ICalculationIterator
    {
        public Collection CalculationHistory;
        public int Index = 0;
        public int NextI = 1;
        public int PreviousI = -1;

        // Iterator Constructor (Iterator Design Pattern)
        public Iterator(Collection history)
        {
            this.CalculationHistory = history;
        }

        public void Next(ICalculatorComponent calculator)
        {
            Index += NextI;
            bool end = EndOfCollection();

            while (!end)
            {
                ShowSingle(Index, calculator);
                end = true;
            }

            end = EndOfCollection();
            while (end)
            {
                Index = CalculationHistory.Count - 1;
                WriteToConsole.Write("\nYou are at the end of the calculation history.");
                Last(calculator);
                end = false;
            }
        }

        public void Previous(ICalculatorComponent calculator)
        {
            Index += PreviousI;
            bool end = EndOfCollection();
            int temp = Index;

            while (temp >= 0)
            {
                while (!end)
                {
                    ShowSingle(Index, calculator);
                    end = true;
                }

                temp = -1;
            }

            temp = Index;
            while (temp < 0)
            {
                Index = 0;
                temp = Index;
                WriteToConsole.Write("\nYou are at the beginning of the calculation history.");
                First(calculator);
            }
        }

        public void First(ICalculatorComponent calculator)
        {
            Index = 0;
            ShowSingle(Index, calculator);
        }

        public void Last(ICalculatorComponent calculator)
        {
            Index = CalculationHistory.Count - 1;
            ShowSingle(Index, calculator);
        }

        public void Current(ICalculatorComponent calculator)
        {
            ShowSingle(Index, calculator);
        }

        public Calculation CurrentCalculation(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[Index];
        }

        public void SetTwoVariableCalculation(ICalculatorComponent calculator, Calculation updated, String newSign)
        {
            calculator.CalculationHistory[Index] = Calculation.Create(updated.A, updated.B, updated.Operation, calculator);
            calculator.UserOperations[Index] = newSign;
            calculator.CalculatorState[Index] = new Context(new Modified());
        }

        public void SetOneVariableCalculation(ICalculatorComponent calculator, Calculation updated, String newSign)
        {
            calculator.CalculationHistory[Index] = Calculation.Create(updated.A, 0, updated.Operation, calculator);
            calculator.UserOperations[Index] = newSign;
            calculator.CalculatorState[Index] = new Context(new Modified());
        }

        public int GetIndex()
        {
            return Index;
        }
        public bool EndOfCollection()
        {
            return Index >= CalculationHistory.Count;
        }

        public void ShowSingle(int i, ICalculatorComponent calculator)
        {
            int num = i;
            int location = 0;
            foreach (String s in calculator.UserOperations)
            {
                String sign = s;

                while (i == location)
                {

                    num += 1;

                    while (sign.Equals("+"))
                    {
                        WriteToConsole.Write("\n>>> Calculation #" + num.ToString() + " | " +
                                      calculator.CalculationHistory[i].A + " " + sign + " " +
                                      calculator.CalculationHistory[i].B + " = " +
                                      calculator.CalculationHistory[i].Operation(
                                          calculator.CalculationHistory[i].A,
                                          calculator.CalculationHistory[i].B));
                        sign = "";
                    }

                    while (sign.Equals("-"))
                    {
                        WriteToConsole.Write("\n>>> Calculation #" + num.ToString() + " | " +
                                      calculator.CalculationHistory[i].A + " " + sign + " " +
                                      calculator.CalculationHistory[i].B + " = " +
                                      calculator.CalculationHistory[i].Operation(
                                          calculator.CalculationHistory[i].A,
                                          calculator.CalculationHistory[i].B));
                        sign = "";
                    }

                    while (sign.Equals("*"))
                    {
                        WriteToConsole.Write("\n>>> Calculation #" + num.ToString() + " | " +
                                      calculator.CalculationHistory[i].A + " " + sign + " " +
                                      calculator.CalculationHistory[i].B + " = " +
                                      calculator.CalculationHistory[i].Operation(
                                          calculator.CalculationHistory[i].A,
                                          calculator.CalculationHistory[i].B));
                        sign = "";
                    }

                    while (sign.Equals("/"))
                    {
                        WriteToConsole.Write("\n>>>Calculation #" + num.ToString() + " | " +
                                      calculator.CalculationHistory[i].A + " " + sign + " " +
                                      calculator.CalculationHistory[i].B + " = " +
                                      calculator.CalculationHistory[i].Operation(
                                          calculator.CalculationHistory[i].A,
                                          calculator.CalculationHistory[i].B));
                        sign = "";
                    }

                    while (sign.Equals("SQUARE ROOT OF"))
                    {
                        WriteToConsole.Write("\n>>>Calculation #" + num.ToString() + " | " + sign + " " +
                                      calculator.CalculationHistory[i].A + " = " +
                                      calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, 0));
                        sign = "";
                    }

                    while (sign.Equals("SQUARE OF"))
                    {
                        WriteToConsole.Write("\n>>>Calculation #" + num.ToString() + " | " + sign + " " +
                                      calculator.CalculationHistory[i].A + " = " +
                                      calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, 0));
                        sign = "";
                    }

                    location += 1;
                }

                location += 1;
            }
        }

        public void ShowAll(ICalculatorComponent calculator)
        {
            int num = 1;
            int i = 0;
            int j = 0;
            foreach (String s in calculator.UserOperations)
            {
                String sign = s;
                bool again = true;

                while (again)
                {
                    try
                    {
                        while (sign.Equals("+"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                              calculator.CalculationHistory[i].A + " " + sign + " " +
                                              calculator.CalculationHistory[i].B + " = " + calculator
                                                  .CalculationHistory[i].Operation(
                                                      calculator.CalculationHistory[i].A,
                                                      calculator.CalculationHistory[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("-"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                          calculator.CalculationHistory[i].A + " " + sign + " " +
                                          calculator.CalculationHistory[i].B + " = " + calculator
                                              .CalculationHistory[i].Operation(
                                                  calculator.CalculationHistory[i].A,
                                                  calculator.CalculationHistory[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("*"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                          calculator.CalculationHistory[i].A + " " + sign + " " +
                                          calculator.CalculationHistory[i].B + " = " + calculator
                                              .CalculationHistory[i].Operation(
                                                  calculator.CalculationHistory[i].A,
                                                  calculator.CalculationHistory[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("/"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                          calculator.CalculationHistory[i].A + " " + sign + " " +
                                          calculator.CalculationHistory[i].B + " = " + calculator
                                              .CalculationHistory[i].Operation(
                                                  calculator.CalculationHistory[i].A,
                                                  calculator.CalculationHistory[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE ROOT OF"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " + sign + " " +
                                          calculator.CalculationHistory[i].A + " = " +
                                          calculator.CalculationHistory[i]
                                              .Operation(calculator.CalculationHistory[i].A, 0));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE OF"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " + sign + " " +
                                          calculator.CalculationHistory[i].A + " = " +
                                          calculator.CalculationHistory[i]
                                              .Operation(calculator.CalculationHistory[i].A, 0));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }

                    j += 1;
                    while (j > 25)
                    {
                        again = false;
                        j = 0;
                    }
                }

            }
        }

        public void ShowState(ICalculatorComponent calculator)
        {
            int num = 1;
            int i = 0;
            int j = 0;
            foreach (String s in calculator.UserOperations)
            {
                String sign = s;
                bool again = true;

                while (again)
                {
                    try
                    {
                        while (sign.Equals("+"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                           calculator.CalculationHistory[i].A + " " + sign + " " +
                                           calculator.CalculationHistory[i].B + " = " + calculator
                                               .CalculationHistory[i].Operation(
                                                   calculator.CalculationHistory[i].A,
                                                   calculator.CalculationHistory[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("-"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                          calculator.CalculationHistory[i].A + " " + sign + " " +
                                          calculator.CalculationHistory[i].B + " = " + calculator
                                              .CalculationHistory[i].Operation(
                                                  calculator.CalculationHistory[i].A,
                                                  calculator.CalculationHistory[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("*"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                          calculator.CalculationHistory[i].A + " " + sign + " " +
                                          calculator.CalculationHistory[i].B + " = " + calculator
                                              .CalculationHistory[i].Operation(
                                                  calculator.CalculationHistory[i].A,
                                                  calculator.CalculationHistory[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("/"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " +
                                          calculator.CalculationHistory[i].A + " " + sign + " " +
                                          calculator.CalculationHistory[i].B + " = " + calculator
                                              .CalculationHistory[i].Operation(
                                                  calculator.CalculationHistory[i].A,
                                                  calculator.CalculationHistory[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE ROOT OF"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " + sign + " " +
                                          calculator.CalculationHistory[i].A + " = " +
                                          calculator.CalculationHistory[i]
                                              .Operation(calculator.CalculationHistory[i].A, 0) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE OF"))
                        {
                            WriteToConsole.Write("Calculation #" + num.ToString() + " | " + sign + " " +
                                          calculator.CalculationHistory[i].A + " = " +
                                          calculator.CalculationHistory[i]
                                              .Operation(calculator.CalculationHistory[i].A, 0) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }

                    j += 1;
                    while (j > 25)
                    {
                        again = false;
                        j = 0;
                    }
                }

            }
        }

    }
}

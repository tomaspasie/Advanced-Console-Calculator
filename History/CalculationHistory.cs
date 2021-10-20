using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Events;
using CalculatorProject.Facade;
using CalculatorProject.Iterator;

namespace CalculatorProject.History
{
    // Facade Class
    class CalculationHistory
    {
        public static void Activate(ICalculatorComponent calculator, String userInput)
        {

            Collection collection = new Collection();

            foreach (Calculation _calculation in calculator.CalculationHistory)
            {
                collection.CalculationHistory.Add(_calculation);
            }

            Iterator.Iterator iterator = collection.CreateIterator();
            
            
            // | 1 | View Calculation History (Format: Entire List)
            while (userInput.Equals("1"))
            {
                Prompts.ShowHistory();
                iterator.ShowAll(calculator);
                Prompts.Back();
                String enter = Console.ReadLine();
                userInput = "pass";
            }

            // | 2 | View Calculation History (Format: One By One)
            while (userInput.Equals("2"))
            {
                String enter = "";

                Prompts.IteratorTitle();
                iterator.First(calculator);

                while (enter != "EXIT")
                {
                    Prompts.IteratorOptions();
                    enter = Console.ReadLine();

                    while (enter.Equals("NEXT"))
                    {
                        iterator.Next(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("PREVIOUS"))
                    {
                        iterator.Previous(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("FIRST"))
                    {
                        iterator.First(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("LAST"))
                    {
                        iterator.Last(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("CHANGE"))
                    {
                        Prompts.ShowEdit();
                        Receiver.DisplayOperations(calculator, "");
                        string operation = Console.ReadLine();

                        CalculationManipulation manipulator = new CalculationManipulation();
                        Calculation oldCalculation = iterator.CurrentCalculation(calculator);
                        manipulator.EditCalculation(operation, oldCalculation, calculator, iterator);

                        iterator.Current(calculator);
                        WriteToConsole.Write("");

                        Prompts.Changed();
                        string temp = Console.ReadLine();
                        enter = "EXIT";
                    }

                    while (enter.Equals("REMOVE"))
                    {
                        CalculationManipulation manipulator = new CalculationManipulation();
                        manipulator.RemoveCalculation(calculator, iterator.GetIndex());
                        enter = "pass";
                        Prompts.Removed();
                        string temp = Console.ReadLine();
                        enter = "EXIT";
                    }

                    while ((!enter.Equals("NEXT")) && (!enter.Equals("PREVIOUS")) && (!enter.Equals("FIRST")) && (!enter.Equals("LAST") && (!enter.Equals("CHANGE") && (!enter.Equals("REMOVE")) && (!enter.Equals("pass")) && (!enter.Equals("EXIT")))))
                    {
                        Prompts.Enter();
                        string temp = Console.ReadLine();
                        enter = "pass";
                    }
                }

                userInput = "pass";
            }

            // | 5 | Check State Of All Calculations
            while (userInput.Equals("5"))
            {
                Prompts.StateTitle();
                iterator.ShowState(calculator);
                Prompts.StateOptions();
                String enter = Console.ReadLine();
                userInput = "pass";
            }
        }
    }
}

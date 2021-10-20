using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;
using CalculatorProject.Events;
using CalculatorProject.State;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Concrete Command Class (Command Design Pattern)
    class SubtractionCommand : Command
    {
        private const string Subtraction = "subtraction";
        private const string Choice = "subtraction_USER_CHOICE";

        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Subtraction);
        }

        public override bool UserChoiceCheck(Invoker command)
        {
            return command.OperationString.Equals(Choice);
        }

        public override ICalculatorComponent Execute(Invoker command, ICalculatorComponent calculator)
        {
            bool check = UserInputCheck(command);
            while (check)
            {
                calculator.OnAdd_Subtraction(calculator);
                calculator.TempOperations.Add("Subtraction", new SubtractionDecorator(calculator));
                calculator = Events.Subtraction.Handler(calculator);
                check = false;
            }

            return calculator;
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Prompts.Subtraction();

                double a, b;
                double result;

                Prompts.FirstNumber();
                a = Convert.ToDouble(Console.ReadLine());
                Prompts.SecondNumber();
                b = Convert.ToDouble(Console.ReadLine());

                calculator.Operations["subtraction"].CreateCalculation(calculator, a, b);
                result = calculator.Operations["subtraction"].GetResult(calculator);

                Prompts.Result(result);

                calculator.UserOperations.Add("-");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }

    }
}

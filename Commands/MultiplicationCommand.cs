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
    class MultiplicationCommand : Command
    {
        private const string Multiplication = "multiplication";
        private readonly string _choice = "multiplication_USER_CHOICE";
        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Multiplication);
        }
        public override bool UserChoiceCheck(Invoker command)
        {
            return command.OperationString.Equals(_choice);
        }

        public override ICalculatorComponent Execute(Invoker command, ICalculatorComponent calculator)
        {
            bool check = UserInputCheck(command);
            while (check)
            {
                calculator.OnAdd_Multiplication(calculator);
                calculator.TempOperations.Add("Multiplication", new MultiplicationDecorator(calculator));
                calculator = Events.Multiplication.Handler(calculator);
                check = false;
            }

            return calculator;
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Prompts.Multiplication();

                double a, b;
                double result;

                Prompts.FirstNumber();
                a = Convert.ToDouble(Console.ReadLine());
                Prompts.SecondNumber();
                b = Convert.ToDouble(Console.ReadLine());

                calculator.Operations["multiplication"].CreateCalculation(calculator, a, b);
                result = calculator.Operations["multiplication"].GetResult(calculator);

                Prompts.Result(result);

                calculator.UserOperations.Add("*");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }

    }
}

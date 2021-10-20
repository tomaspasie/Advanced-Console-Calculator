using System;
using CalculatorProject.Commands;

namespace CalculatorProject.Events
{

    class Publisher
    {
        public event EventHandler AddOperation;

        public string Operation;

        public virtual void OnAddOperation(EventArgs e)
        {
            AddOperation?.Invoke(this, e);
        }

        // The event adds functionality based on user input.
        public virtual ICalculatorComponent AddFunctionality(Invoker command, ICalculatorComponent calculator)
        {
            Operation = command.OperationString;
            command.Addition.Execute(command, calculator);
            command.Subtraction.Execute(command, calculator);
            command.Multiplication.Execute(command, calculator);
            command.Division.Execute(command, calculator);
            command.SquareRoot.Execute(command, calculator);
            command.Square.Execute(command, calculator);
            OnAddOperation(EventArgs.Empty);

            return calculator;
        }

        public override string ToString()
        {
            return Operation;
        }
    }
}

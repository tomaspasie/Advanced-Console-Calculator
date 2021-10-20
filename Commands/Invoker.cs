using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.Commands
{
    // Invoker Class (Command Design Pattern)
    class Invoker
    {
        public string OperationString { get; set; }
        public AdditionCommand Addition { get; set; }
        public SubtractionCommand Subtraction { get; set; }
        public MultiplicationCommand Multiplication { get; set; }
        public DivisionCommand Division { get; set; }
        public SquareRootCommand SquareRoot { get; set; }
        public SquareCommand Square { get; set; }

        public Invoker(string userInput)
        {
            OperationString = userInput;
            Addition = new AdditionCommand();
            Subtraction = new SubtractionCommand();
            Multiplication = new MultiplicationCommand();
            Division = new DivisionCommand();
            SquareRoot = new SquareRootCommand();
            Square = new SquareCommand();
        }

    }
}

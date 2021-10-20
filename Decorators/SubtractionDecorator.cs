using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Subtraction Decorator (Decorator Design Pattern)
    class SubtractionDecorator : CalculatorDecorator
    {
        public SubtractionDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var difference = Calculation.Create(a, b, Operations.Subtraction, calculator);

            return difference;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[^1].Operation(calculator.CalculationHistory[^1].A, calculator.CalculationHistory[^1].B);
        }
    }
}
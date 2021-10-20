using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Multiplication Decorator (Decorator Design Pattern)
    class MultiplicationDecorator : CalculatorDecorator
    {
        public MultiplicationDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var product = Calculation.Create(a, b, Operations.Multiplication, calculator);

            return product;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[^1].Operation(calculator.CalculationHistory[^1].A, calculator.CalculationHistory[^1].B);
        }
    }
}
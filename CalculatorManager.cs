using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CalculatorProject.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    class CalculatorManager
    {
        // Calculator Manager
        public CalculatorManager(ILogger<CalculatorManager> logger)
        {
            Calculator calculator = new Calculator();
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber(publisher);

            ConsoleManager.Activate(calculator, publisher, logger);

            subscriber.UnSubscribeEvent();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.Events
{
    abstract class Event
    {
        static void Handler(ICalculatorComponent calculator) { }
    }
}

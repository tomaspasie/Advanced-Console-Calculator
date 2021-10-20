using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.State
{
    // Abstract State Class (State Design Pattern)
    abstract class State
    {
        public abstract void Handle(Context context);
    }
}

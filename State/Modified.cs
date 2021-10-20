using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.State
{
    // Concrete State Class (State Design Pattern)
    class Modified : State
    {
        public override void Handle(Context context)
        {
            context.State = new Modified();
        }
    }
}

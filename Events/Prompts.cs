using System;

namespace CalculatorProject.Events
{
    class Prompts
    {
        public static void Intro()
        {
            WriteToConsole.Write("------------------------");
            WriteToConsole.Write("| Calculator Activated |");
            WriteToConsole.Write("------------------------\n");
        }

        public static void Functionality()
        {
            WriteToConsole.Write("What operation functionality would you like to give the calculator? (Enter one at a time.)");
            WriteToConsole.Write("Options: addition, subtraction, multiplication, division, square root, square\n");
        }

        public static void _Functionality()
        {
            WriteToConsole.Write("\nEnter another operation functionality or type 'DONE' to continue.\n");
        }

        public static void Addition()
        {
            WriteToConsole.Write("\n\n- - - - - - - - - - -");
            WriteToConsole.Write("YOU CHOSE: Addition");
            WriteToConsole.Write("- - - - - - - - - - -\n");
        }

        public static void Subtraction()
        {
            WriteToConsole.Write("\n\n- - - - - - - - - - - -");
            WriteToConsole.Write("YOU CHOSE: Subtraction");
            WriteToConsole.Write("- - - - - - - - - - - -\n");
        }

        public static void Multiplication()
        {
            WriteToConsole.Write("\n\n- - - - - - - - - - - - - -");
            WriteToConsole.Write("YOU CHOSE: Multiplication");
            WriteToConsole.Write("- - - - - - - - - - - - - -\n");
        }

        public static void Division()
        {
            WriteToConsole.Write("\n\n- - - - - - - - - - -");
            WriteToConsole.Write("YOU CHOSE: Division");
            WriteToConsole.Write("- - - - - - - - - - -\n");
        }

        public static void SquareRoot()
        {
            WriteToConsole.Write("\n\n- - - - - - - - - - - -");
            WriteToConsole.Write("YOU CHOSE: Square Root");
            WriteToConsole.Write("- - - - - - - - - - - -\n");
        }

        public static void Square()
        {
            WriteToConsole.Write("\n\n- - - - - - - - - -");
            WriteToConsole.Write("YOU CHOSE: Square");
            WriteToConsole.Write("- - - - - - - - - -\n");
        }

        public static void Number()
        {
            WriteToConsole.Write("Enter number:");
        }

        public static void FirstNumber()
        {
            WriteToConsole.Write("Enter first number:");
        }

        public static void SecondNumber()
        {
            WriteToConsole.Write("\nEnter second number:");
        }

        public static void _Number()
        {
            WriteToConsole.Write("\nEnter number:");
        }

        public static void _FirstNumber()
        {
            WriteToConsole.Write("\nEnter first number:");
        }

        public static void _SecondNumber()
        {
            WriteToConsole.Write("\nEnter second number:");
        }

        public static void Zero()
        {
            WriteToConsole.Write("\nThis number cannot be 0.");
            WriteToConsole.Write("Please enter another number:");
        }

        public static void Divider()
        {
            WriteToConsole.Write("\n-----------------------------------------");
        }

        public static void Result(double result)
        {
            WriteToConsole.Write("\n---------------------------------");
            WriteToConsole.Write("ANSWER: " + Convert.ToString(result));
            WriteToConsole.Write("---------------------------------");
        }

        public static void Logger()
        {
            WriteToConsole.Write("\n---------------LOGGER---------------");
            WriteToConsole.Write("NOTE: Calculation will be skipped.");
        }

        public static void ChooseOperation()
        {
            WriteToConsole.Write("\n-----------------------------------------------------");
            WriteToConsole.Write("| Choose the operation you would like to calculate. |");
            WriteToConsole.Write("-----------------------------------------------------");
        }

        public static void Another()
        {
            WriteToConsole.Write("\n------------------------------------");
            WriteToConsole.Write("| Do another calculation? (YES/NO) |");
            WriteToConsole.Write("------------------------------------");
        }

        public static void Options()
        {
            WriteToConsole.Write("\n----------------------------------------------------------------------------------------------------------");
            WriteToConsole.Write("|                            OPTIONS: Choose an option by entering its number                            |");
            WriteToConsole.Write("----------------------------------------------------------------------------------------------------------");
            WriteToConsole.Write("| 1 | View Calculation History (Entire List)");
            WriteToConsole.Write("| 2 | View/Modify Calculation History [NEXT, PREVIOUS, FIRST, LAST, CHANGE, REMOVE]");
            WriteToConsole.Write("| 3 | Create New Calculations");
            WriteToConsole.Write("| 4 | Display What The Calculator Is Capable Of Doing (In Its Current State)");
            WriteToConsole.Write("| 5 | Check State Of All Calculations");
            WriteToConsole.Write("| 6 | Exit Program");
            WriteToConsole.Write("----------------------------------------------------------------------------------------------------------\n");
        }

        public static void ShowHistory()
        {
            WriteToConsole.Write("\n--------------------------------------");
            WriteToConsole.Write("| SHOWING ENTIRE CALCULATION HISTORY |");
            WriteToConsole.Write("--------------------------------------");
        }

        public static void ShowEdit()
        {
            WriteToConsole.Write("\n-------------------------------------------------------------");
            WriteToConsole.Write("|                     EDIT CALCULATION                      |");
            WriteToConsole.Write("-------------------------------------------------------------\n");
            WriteToConsole.Write("What Operation Do You Want To Change This Calculation To?");
        }

        public static void Changed()
        {
            WriteToConsole.Write("------------------------------------------------------------------------");
            WriteToConsole.Write("|  CALCULATION SUCCESSFULLY CHANGED | Press ENTER To Return To Options |");
            WriteToConsole.Write("------------------------------------------------------------------------");
        }

        public static void Removed()
        {
            WriteToConsole.Write("\n-----------------------------------------------------------");
            WriteToConsole.Write("|  CALCULATION REMOVED | Press ENTER To Return To Options |");
            WriteToConsole.Write("-----------------------------------------------------------");
        }

        public static void IteratorTitle()
        {
            WriteToConsole.Write("\n------------------------------------------------------------------------------------------------------");
            WriteToConsole.Write("|                                   SHOWING CALCULATIONS ONE BY ONE                                  |");
            WriteToConsole.Write("------------------------------------------------------------------------------------------------------");
        }

        public static void IteratorOptions()
        {
            WriteToConsole.Write("\n------------------------------------------------------------------------------------------------------");
            WriteToConsole.Write("| Choose An Option: NEXT, PREVIOUS, FIRST, LAST, CHANGE, REMOVE  | Or Type EXIT To Return To Options |");
            WriteToConsole.Write("------------------------------------------------------------------------------------------------------\n");
        }

        public static void StateTitle()
        {
            WriteToConsole.Write("\n--------------------------------------");
            WriteToConsole.Write("| CURRENT STATE OF ALL CALCULATIONS |");
            WriteToConsole.Write("--------------------------------------");
        }

        public static void StateOptions()
        {
            WriteToConsole.Write("--------------------------------------");
            WriteToConsole.Write("|  Press ENTER To Return To Options  |");
            WriteToConsole.Write("--------------------------------------");
        }

        public static void Capability()
        {
            WriteToConsole.Write("\n------------------------------------------");
            WriteToConsole.Write("| THE CALCULATOR IS CURRENTLY CAPABLE OF |");
            WriteToConsole.Write("------------------------------------------\n");
        }

        public static void Back()
        {
            WriteToConsole.Write("--------------------------------------");
            WriteToConsole.Write("|  Press ENTER To Return To Options  |");
            WriteToConsole.Write("--------------------------------------");
        }

        public static void Unavailable()
        {
            WriteToConsole.Write("\nThat is not available. Press ENTER To Return To Options.\n");
        }

        public static void Enter()
        {
            WriteToConsole.Write("\nThat is not available. Press ENTER To Return.");
        }

        public static void NotAvailable()
        {
            WriteToConsole.Write("\nThat is not available. Please choose another.\n");
        }

        public static void Outro()
        {
            WriteToConsole.Write("\n------------");
            WriteToConsole.Write("| Goodbye! |");
            WriteToConsole.Write("------------");
        }

    }
}

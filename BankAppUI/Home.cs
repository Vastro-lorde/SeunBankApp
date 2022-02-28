using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppUI
{
    public class Home
    {
        public static void WelcomePage()
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("Welcome to Spirit Bank of Souls");
            PrintTable.PrintLine();
            Inputs.Instruction("Please Sign-up or Login");
        }
    }
}

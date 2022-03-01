using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeunBankAppCore;

namespace BankAppUI1
{
    public class Home
    {
        public static void WelcomePage()
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("<<<<<<< || Welcome to SPIRIT BANK of Souls || >>>>>>>");
            PrintTable.PrintLine();
            Inputs.Instruction("Please Sign-up or Login by selecting 1 or 2:");
            Inputs.Instruction("1. Signup.");
            Inputs.Instruction("2. Login.");
        }
        public static void AccountDetailsTable()
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("FULLNAME","ACCOUNT NUMBER","ACCOUNT TYPE","ACCOUNT BALANCE");
            PrintTable.PrintLine();
            PrintTable.PrintLine();
        }

        public static void TransactionsTable()
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("DATE", "DESCRIPTION", "AMOUNT", "ACCOUNT BALANCE");
            PrintTable.PrintLine();
            PrintTable.PrintLine();
        }

       

    }
}

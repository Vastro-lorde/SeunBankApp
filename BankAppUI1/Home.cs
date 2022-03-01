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
        public static void AccountDetailsTable(SBankAccount account)
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("FULLNAME","ACCOUNT NUMBER","ACCOUNT TYPE","ACCOUNT BALANCE");
            PrintTable.PrintLine();
            SAccounts.ListOfBankAccounts.ForEach(bankAccount =>
            {
                if (account.Email == bankAccount.Email && Validations.VerifyPassword(bankAccount.Password, account))
                {
                    PrintTable.PrintRow(bankAccount.AccountName, bankAccount.AccountNumber, bankAccount.AccountType, bankAccount.AccountBalance.ToString());
                }
            });
            PrintTable.PrintLine();
        }

        public static void TransactionsTable()
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("DATE", "DESCRIPTION", "AMOUNT", "ACCOUNT BALANCE");
            PrintTable.PrintLine();
            PrintTable.PrintLine();
        }

        public static bool AccountActions(SBankAccount account)
        {
            bool running = true;
            while (running)
            {
                Inputs.Instruction("Choose Your Next Action:\n" +
                        "1. Open Another account. \n" +
                        "2. Withdraw. \n" +
                        "3. Deposit. \n" +
                        "4. Transfer. \n" +
                        "Return to the main menu by making any other input.");
                string action = Inputs.Collect("choice");
                if (action == "1")
                {
                    continue;
                }
                if (action == "2")
                {

                }
                if (action == "3")
                {

                }
                if (action == "4")
                {

                }
                continue;
            }
            return running; 
        }
       

    }
}

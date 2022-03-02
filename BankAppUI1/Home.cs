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
            Inputs.Instruction("3. Exit.");
        }
        public static void AccountDetailsTable(SBankAccount account)
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("FULLNAME","ACCOUNT NUMBER","ACCOUNT TYPE","ACCOUNT BALANCE");
            PrintTable.PrintLine();
            SAccounts.ListOfBankAccounts.ForEach(bankAccount =>
            {
                if (account.Email == bankAccount.Email && Validations.EqualPassword(bankAccount.Password, account))
                {
                    PrintTable.PrintRow(bankAccount.AccountName, bankAccount.AccountNumber, bankAccount.AccountType, bankAccount.AccountBalance.ToString());
                }
            });
            PrintTable.PrintLine();
        }

        public static void TransactionsTable(SBankAccount account)
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow("DATE", "DESCRIPTION", "AMOUNT", "ACCOUNT BALANCE");
            PrintTable.PrintLine();
            account.ListOfTransactions.ForEach(transaction =>
            {
                PrintTable.PrintRow(transaction.TransactionDate,transaction.TransactionDescription,transaction.TransactionAmount.ToString() +" "+ transaction.TransactionType,account.AccountBalance.ToString());
            });
            PrintTable.PrintLine();
        }
       

    }
}

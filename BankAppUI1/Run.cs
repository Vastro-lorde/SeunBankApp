using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeunBankAppCore;

namespace BankAppUI1
{
    public class Run
    {
        public static void Bank()
        {
            bool run = true;
            while (run)
            {
                Home.WelcomePage();
                string choice = Inputs.Collect("choice");
                if (choice == "1")
                {
                    Inputs.Instruction("Choose Account type:\n" +
                        "1. Savings. \n" +
                        "2. Current.");
                    string accountType = 
                        Inputs.Collect("accountType") == "1" ? "Savings": "Current";
                    Inputs.Instruction("Please input your Email");
                    string email = Inputs.CollectEmail("email");
                    Inputs.Instruction("Please input your Password");
                    string password = Inputs.CollectPassword("password");
                    Inputs.Instruction("Please input your Fullname");
                    string accountName = Inputs.CollectText("fullname");
                    var account = Service.CreateAccount(accountName, password, email, accountType);
                    Inputs.Clean();
                    Home.AccountDetailsTable(account);

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
                            Inputs.Withdraw(account);
                        }
                        if (action == "3")
                        {
                            Inputs.Deposit(account);
                        }
                        if (action == "4")
                        {
                            Inputs.TransferFund(account);
                        }
                        continue;
                    }
                     running = false;
                }
                if (choice == "2")
                {
                    Inputs.Instruction("Please input your Email");
                    string email = Inputs.CollectEmail("email");
                    Inputs.Instruction("Please input your Password");
                    string password = Inputs.CollectPassword("password");
                    if (SAccounts.ListOfBankAccounts.Count < 0) Inputs.Instruction("Account doesn't exist");
                    var accounts = Service.LoginAccount(email, password);
                    Inputs.Instruction("Choose account");
                    accounts.ForEach(account =>
                    {
                        Inputs.Instruction($"{accounts.IndexOf(account)}. {account.AccountName}: {account.AccountNumber}");
                    });
                    string chosenAccount = Inputs.Collect("choice");

                    if (accounts.Count < 0 || accounts.Count < Convert.ToInt32(chosenAccount)) Inputs.Instruction("Account doesn't exist");

                    var account = accounts[Convert.ToInt32(chosenAccount)];

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
                            Inputs.Withdraw(account);
                        }
                        if (action == "3")
                        {
                            Inputs.Deposit(account);
                        }
                        if (action == "4")
                        {
                            Inputs.TransferFund(account);
                        }
                        continue;
                    }
                    running = false;
                }
                continue;
            }
            
            Home.TransactionsTable();
        }
    }
}

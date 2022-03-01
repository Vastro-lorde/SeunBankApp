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
                        Inputs.Collect("accountType") == "1" ? "Savings": 
                        Inputs.Collect("accountType") == "2" ? "Current" : 
                        Inputs.Collect("accountType");
                    Inputs.Instruction("Please input your Email");
                    string email = Inputs.CollectEmail("email");
                    Inputs.Instruction("Please input your Password");
                    string password = Inputs.CollectPassword("password");
                    Inputs.Instruction("Please input your Fullname");
                    string accountName = Inputs.CollectText("fullname");
                    var account = Service.CreateAccount(accountName, password, email, accountType);
                    Inputs.Clean();
                    Home.AccountDetailsTable(account);
                    
                }
                if (choice == "2")
                {
                    Inputs.Instruction("Please input your Email");
                    string email = Inputs.CollectEmail("email");
                    Inputs.Instruction("Please input your Password");
                    string password = Inputs.CollectPassword("password");
                }
                continue;
            }
            
            Home.TransactionsTable();
        }
    }
}

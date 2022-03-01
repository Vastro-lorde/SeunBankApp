using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeunBankApp;

namespace BankAppUI
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

                }
            }
            
            Home.AccountDetailsTable();
            Home.TransactionsTable();
        }
    }
}

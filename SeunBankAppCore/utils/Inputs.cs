using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeunBankAppCore
{
    public class Inputs
    {
        public static void Instruction(string instruct) => Console.WriteLine(instruct);
        public static string CollectText(string data) =>  Console.ReadLine();
        public static void Clean() => Console.Clear();
        public static string Collect(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.VerifyNumberInputType(data))
                {
                    Inputs.Instruction("please correct your input");
                    continue;
                }
                runing = false;
            }
            return data;
        }

        public static decimal CollectAmount(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.VerifyAmountInputType(data))
                {
                    Inputs.Instruction("please correct your input");
                    continue;
                }
                runing = false;
            }
            return Convert.ToDecimal(data);
        }
        public static string CollectEmail(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.VerifyEmail(data))
                {
                    Inputs.Instruction("please correct your input");
                    continue;
                }
                runing = false;
            }
            return data;
        }
        public static string CollectPassword(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.CheckPasswordInput(data))
                {
                    Inputs.Instruction("please correct your input");
                    continue;
                }
                runing = false;
            }
            return data;
        }

        public static void Withdraw(SBankAccount account)
        {
            Inputs.Instruction("Choose means of Withdrawer: \n" +
                                "1. ATM terminal. \n" +
                                "2. POS Agent. \n" +
                                "3. Bank.");
            string transactionDescription =
                Inputs.Collect("Description") == "1" ? "ATM terminal" :
                Inputs.Collect("Description") == "2" ? "POS Agent" :
                Inputs.Collect("Description") == "3" ? "Bank" :
                "Bank";
            Inputs.Instruction("Input Amount to be withdrawn");
            decimal amount = Inputs.CollectAmount("amount");
            string result = Service.NewTransaction(-amount, transactionDescription, account) ? "Successful" : "Withdrawal Failed";
            Inputs.Instruction(result);
        }

        public static void Deposit(SBankAccount account)
        {
            Inputs.Instruction("Choose means of Deposition: \n" +
                                "1. ATM terminal. \n" +
                                "2. POS Agent. \n" +
                                "3. Bank.");
            string transactionDescription =
                Inputs.Collect("Description") == "1" ? "ATM terminal" :
                Inputs.Collect("Description") == "2" ? "POS Agent" :
                Inputs.Collect("Description") == "3" ? "Bank" :
                "Bank";
            Inputs.Instruction("Input Amount to be withdrawn");
            decimal amount = Inputs.CollectAmount("amount");
            string result = Service.NewTransaction(amount, transactionDescription, account) ? "Successful" : "Withdrawal Failed";
            Inputs.Instruction(result);
        }

        public static void TransferFund(SBankAccount account)
        {
            Inputs.Instruction("Choose means of Transfer: \n" +
                                "1. ATM terminal. \n" +
                                "2. POS Agent. \n" +
                                "3. Bank.");
            string transactionDescription =
                Inputs.Collect("Description") == "1" ? "ATM terminal" :
                Inputs.Collect("Description") == "2" ? "POS Agent" :
                Inputs.Collect("Description") == "3" ? "Bank" :
                "Bank";
            Inputs.Instruction("Input Amount to be Transfer");
            decimal amount = Inputs.CollectAmount("amount");
            Inputs.Instruction("Input account number to send funds");
            string destinationAccoutNumber = Inputs.CollectText("destinationAccount");

            if (SAccounts.ListOfBankAccounts.Count < 0) Inputs.Instruction("Account doesn't exist");

            SBankAccount destinationAccount = Service.GetAccount(destinationAccoutNumber);

            /* Creates the transaction record in destination account records */
            string transfer = Service.NewTransaction(amount, $"Recieved {amount} via " + transactionDescription + $" from {account.AccountName}", destinationAccount) ? $"Transfer of {amount} Successful to {destinationAccount.AccountNumber}" : "Transfer Failed";
            Inputs.Instruction(transfer);

            /* Creates the transaction record in account records */
            string result = Service.NewTransaction(-amount, transactionDescription, account) ? $"Transfer of {amount} Successful to {destinationAccount.AccountNumber}" : "Withdrawal Failed";
            Inputs.Instruction(result);
        }



    }
}

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
            string transactionDescription = "Withdrawal of funds";
            Inputs.Instruction("Input Amount to be Withdrawn");
            decimal amount = Inputs.CollectAmount("amount");
            string result = Service.NewTransaction(-amount, transactionDescription, account) ? "Successful" : "Withdrawal Failed";
            Inputs.Instruction(result);
        }

        public static void Deposit(SBankAccount account)
        {
            string transactionDescription = "Deposit of funds";
            Inputs.Instruction("Input Amount to be Deposited");
            decimal amount = Inputs.CollectAmount("amount");
            string result = Service.NewTransaction(amount, transactionDescription, account) ? "Successful" : "Deposition Failed";
            Inputs.Instruction(result);
        }

        public static void TransferFund(SBankAccount account)
        {
            string transactionDescription = "Transfer of funds";
            Inputs.Instruction("Input Amount to be Transfered");
            decimal amount = Inputs.CollectAmount("amount");
            Inputs.Instruction("Input account number to send funds");
            string destinationAccoutNumber = Console.ReadLine();

            if (SAccounts.ListOfBankAccounts.Count < 0) Inputs.Instruction("Account doesn't exist");

            SBankAccount destinationAccount = Service.GetAccount(destinationAccoutNumber);

            /* Creates the transaction record in destination account records */
            string transfer = Service.NewTransaction(amount, $"Recieved {amount} via " + transactionDescription + $" from {account.AccountName}", destinationAccount) ? $"Transfer of {amount} Successful to {destinationAccount.AccountNumber}" : "Transfer Failed";
            Inputs.Instruction(transfer);

            /* Creates the transaction record in account records */
            string result = Service.NewTransaction(-amount, transactionDescription, account) ? $"Transfer of {amount} Successful to {destinationAccount.AccountNumber}" : "Transfer Failed";
            Inputs.Instruction(result);
        }



    }
}

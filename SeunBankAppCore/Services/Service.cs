using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace SeunBankAppCore
{
    public static class Service
    {
        public static SBankAccount CreateAccount(string accountName, string password, string email, string accountType )
        {
            SBankAccount account = new SBankAccount();
            account.AccountName = accountName;
            account.Password = BC.HashPassword(password, BC.GenerateSalt(12));
            account.Email = email;
            account.AccountType = accountType;
            account.AccountNumber = CreateAccountNumber();
            SAccounts.ListOfBankAccounts.Add(account);
            return account;
        }

        public static List<SBankAccount> LoginAccount(string email, string password)
        {
            List<SBankAccount> sBankAccounts = new List<SBankAccount>();
            SAccounts.ListOfBankAccounts.ForEach(account =>
            {
                if (account.Email == email && Validations.VerifyPassword(password, account))
                {
                    sBankAccounts.Add(account);
                }
            });
                return sBankAccounts;
        }

        public static string CreateAccountNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1334567812, 1999999999);
            return number.ToString();
        }

        public static bool DeleteAccount(SBankAccount account2Del)
        {
            bool result = false;
            SAccounts.ListOfBankAccounts.ForEach(account =>
            {
                if (account.AccountNumber == account2Del.AccountNumber)
                {
                    SAccounts.ListOfBankAccounts.Remove(account);
                    result = true;
                }
            });
            return result;
        }
        public static STransaction NewTransaction(decimal amount, string description, SBankAccount account)
        {
            STransaction transaction = new STransaction();
            transaction.TransactionAmount = amount;
            transaction.TransactionDescription = description;
            transaction.TransactionDate = DateTime.Now.ToString();

            return transaction;
        }
    }
}

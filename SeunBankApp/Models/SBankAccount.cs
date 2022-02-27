using System;
using System.Collections.Generic;


namespace SeunBankApp
{
    public class SBankAccount
    {
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; }
        public string AccountNumber;
        public decimal AccountBalance {
            get
            {
                decimal Balance = 0;
                foreach (var transaction in ListOfTransactions)
                {
                    Balance += transaction.TransactionAmount;
                }
                return Balance;
            } 
        }

        public List<STransaction> ListOfTransactions = new List<STransaction>();
        
    }
    public class SAccounts
    {
        public static List<SBankAccount> ListOfBankAccounts = new List<SBankAccount>();
    }
    
}

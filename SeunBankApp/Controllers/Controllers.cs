﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace SeunBankApp
{
    public class Controllers
    {
        public SBankAccount CreateAccount(string accountName, string password, string email)
        {
            SBankAccount account = new SBankAccount();
            account.AccountName = accountName;
            account.Password = BC.HashPassword(password, BC.GenerateSalt(12));
            account.Email = email;
            account.AccountNumber = CreateAccountNumber();
            SAccounts.ListOfBankAccounts.Add(account);
            return account;
        }

        public string CreateAccountNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1334567812, 199999999);
            return number.ToString();
        }

        public bool DeleteAccount(SBankAccount account2Del)
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
    }
}

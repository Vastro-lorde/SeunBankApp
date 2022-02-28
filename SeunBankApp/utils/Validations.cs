using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BC = BCrypt.Net.BCrypt;

namespace SeunBankApp
{
    public class Validations
    {
        public bool VerifyPassword( string password, SBankAccount account)
        {
            if (account == null || password == null) return false;
            return BC.Verify(password, account.Password);
        }

        public bool VerifyEmail( string email )
        {
            if(email == null) return false;
            // regular expression for Identifying email using RFC 5322 format if we omit IP addresses, domain-specific addresses
            Regex emailFormat = new Regex(@"\A[a-zA-Z0-9]+(?:\.[a-z0-9!#$%&'*+/=?^_‘{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\z");

            if (emailFormat.IsMatch(email)) return true;

            return false;
        }
    }
}

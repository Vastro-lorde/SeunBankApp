using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace SeunBankApp
{
    public class Validations
    {
        public bool VerifyPassword( string password, SBankAccount account)
        {
            return BC.Verify(password, account.Password);

        }
    }
}

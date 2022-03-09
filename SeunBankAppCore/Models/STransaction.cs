using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeunBankAppCore
{
    public class STransaction
    {
        public string TransactionType 
        {
            get 
            {
                if (TransactionAmount < 0) return "Debit";
                return "Credit";
            } 
        }
        public string TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}

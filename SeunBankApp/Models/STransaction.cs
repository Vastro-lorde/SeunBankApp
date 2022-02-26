using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeunBankApp
{
    internal class SpiritTransaction
    {
        public string TransactionID { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}

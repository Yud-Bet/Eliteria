
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class Transaction
    {
        public int idTransaction { get; set; }
        public int idTransactionType { get; set; }
        public int idSaving { get; set; }
        //public int idStaff { get; set; }
        public string staffName { get; set; }
        public string customerName { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal transactionMoney { get; set; }
        public bool isWithdrawInterest { get; set; }
    }
}
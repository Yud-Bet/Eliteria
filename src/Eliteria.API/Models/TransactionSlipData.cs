using System;

namespace Eliteria.API.Models
{
    public class TransactionSlipData
    {
        public int TransactionTypeID { get; set; }
        public int SavingsID { get; set; }
        public int StaffID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
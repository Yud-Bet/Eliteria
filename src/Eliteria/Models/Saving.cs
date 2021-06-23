using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class Saving
    {
        public int IdSaving { get; set; }
        public int IdCustomer { get; set; }
        public int IdSavingType { get; set; }
        public DateTime OpenDateSaving { get; set; }
        public int TotalSendMoney { get; set; }
        public int TotalWithdrawMoney { get; set; }
        public int InterestMoney { get; set; }
        public int TotalMoney { get; set; }
        public DateTime NextDuedate { get; set; }
        public float InterestRate { get; set; }
        public bool Status { get; set; }
        public System.Nullable<DateTime> CloseDateSaving { get; set; }

        public Customer _Customer { get; set; }
        public SavingType _SavingType { get; set; }
    }
}

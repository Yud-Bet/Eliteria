using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class Saving
    {
        public int idSaving;
        public int idCustomer;
        public int idSavingType;
        public DateTime openDateSaving;
        public int totalSendMoney;
        public int totalWithdrawMoney;
        public int interestMoney;
        public int totalMoney;
        public DateTime nextDuedate;
        public float interestRate;
        public bool status;
        public System.Nullable<DateTime> closeDateSaving;

        public Customer customer { get; set; }
        public SavingType savingType { get; set; }
    }
}

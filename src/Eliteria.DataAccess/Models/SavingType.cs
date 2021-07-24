using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class SavingType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public float InterestRate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int MinNumOfDateToWithdraw { get; set; }
        public string WithdrawalRule { get; set; }
    }
}

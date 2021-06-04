using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class SavingsAccount
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
    }
}

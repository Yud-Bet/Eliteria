using System;

namespace Eliteria.Models
{
    public class SavingsAccount
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }

        public DateTime DoB { get; set; }
        public DateTime OpenDate { get; set; }
    }
}

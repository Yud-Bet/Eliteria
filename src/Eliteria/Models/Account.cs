using System;

namespace Eliteria.Models
{
    public class Account 
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string Password { get; set; }
        public int Position { get; set; }
        public string ID { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }
}

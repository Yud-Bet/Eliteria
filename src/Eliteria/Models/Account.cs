using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    class Account 
    {
        public string StaffName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int Position { get; set; }
        public string ID { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

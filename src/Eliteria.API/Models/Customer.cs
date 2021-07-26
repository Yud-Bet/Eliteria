using System;

namespace Eliteria.API.Models
{
    public class Customer
    {

        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string CMND { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDay { get; set; }
        public int Status { get; set; }



    }
}

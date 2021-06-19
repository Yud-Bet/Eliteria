using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class Saving
    {
        public KHACHHANG customer { get; set; }
        public SOTIETKIEM saving { get; set; }

        public LOAISOTIETKIEM savingType { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess.Models
{
    public class OtherParameter
    {
        public Decimal MinDepositAmount { get; set; }
        public Decimal MinInitialDeposit { get; set; }
        public bool ControlClosingSaving { get; set; }
    }
}

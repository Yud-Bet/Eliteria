using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public partial class Parameter
    {
        private int _MinFirstSendMoney = 1000000;
        public int MinFirstSendMoney { get => _MinFirstSendMoney; set { _MinFirstSendMoney = value; } }
        private int _MinNextSendMoney = 100000;
        public int MinNextSendMoney { get => _MinNextSendMoney; set { _MinNextSendMoney = value; } }
        private bool _ControlClosingSaving = true;
        public bool ControlClosingSaving { get => _ControlClosingSaving; set { _ControlClosingSaving = value; } }
    }
}
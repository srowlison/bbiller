using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Cards
{
    
        public class ChargeResult
        {
            public string failure_message { get; set; }
            public string failure_code { get; set; }
            public string Id { get; set; }

        }
        public class RefundResult
        {
            public string Id { get; set; }
        }
    
}

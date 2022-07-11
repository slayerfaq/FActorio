using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class GPU
    {
        private Copper CU { get; set; }
        private Quartz QU { get; set; }

        public decimal CostQU { get; }
        public decimal CostCU { get; }

        public GPU(Copper copper, Quartz quartz)
        {
            CU = copper;
            QU = quartz;
            
            CostCU = ((BaseMaterial)copper).Cost;
            
            CostQU = ((BaseMaterial)quartz).Cost;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class Monitor
    {
        private Aluminum Al { get; set; }
        private Copper CU { get; set; }
        private Quartz QU { get; set; }

        public decimal CostAL { get; }

        public decimal CostCU { get; }

        public decimal CostQU { get; }

        public Monitor(Aluminum aluminum, Copper copper, Quartz quartz)
        {
            Al = aluminum;
            CU = copper;
            QU = quartz;
            
            CostAL = ((BaseMaterial)aluminum).Cost;
            
            CostAL = ((BaseMaterial)copper).Cost;
            
            CostAL = ((BaseMaterial)quartz).Cost;

            

            
        }
    }
}

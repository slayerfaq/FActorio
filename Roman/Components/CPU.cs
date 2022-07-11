using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class CPU
    {
        private Aluminum Al { get; set; }
        private Copper CU { get; set; }

        public decimal CostAL { get; }
        public decimal CostCU { get; }

        public CPU(Aluminum aluminum, Copper copper)
        {
            Al = aluminum;
            CU = copper;

            CostAL = ((BaseMaterial)aluminum).Cost;
            CostCU = ((BaseMaterial)copper).Cost;
        }
    }
}

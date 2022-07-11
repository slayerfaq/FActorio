using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class Quartz : BaseMaterial
    {
        private string Thermal_Conductivity_Property { get; set; }

        public Quartz() : base("Quartz", 150) { Thermal_Conductivity_Property = "+5"; }

        public override void GetInformationMaterial()
        {
            base.GetInformationMaterial();
            Console.WriteLine($"Thermal_Conductivity_Property: {Thermal_Conductivity_Property}");
        }
    }
}

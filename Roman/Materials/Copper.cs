using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class Copper : BaseMaterial
    {
        private string Electrical_Property  { get; set; }

        public Copper() : base("Copper", 200) { Electrical_Property = "-3"; }

        public override void GetInformationMaterial()
        {
            base.GetInformationMaterial();
            Console.WriteLine($"Electrical_Property: {Electrical_Property}");
        }
    }
}

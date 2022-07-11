using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class Aluminum : BaseMaterial
    {
        private string Chemical_Property { get; set; }

        public Aluminum() : base("Aluminum", 100) { Chemical_Property = "+1"; }

        public override void GetInformationMaterial()
        {
            base.GetInformationMaterial();
            Console.WriteLine($"Chemical_Property: {Chemical_Property}");
        }
    }
}

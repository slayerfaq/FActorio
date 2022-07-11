using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    abstract class BaseMaterial
    {
        protected string Name { get; private set; }
        public decimal Cost { get; private set; }

        public BaseMaterial(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public virtual void GetInformationMaterial()
        {
            Console.WriteLine($"Name: {Name}, Cost: {Cost}");
        }
    }
}

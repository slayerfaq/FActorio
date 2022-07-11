using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class Factory
    {
        private int _amountOfProduction;

        public Factory(int AmountOfProduction)
        {
            _amountOfProduction = AmountOfProduction;
        }

        public List<object> Collector()
        {
            List<Aluminum> aluminum = new List<Aluminum>();
            List<Copper> copper = new List<Copper>();
            List<Quartz> quartz = new List<Quartz>();

            for (int currentProduct = 1; currentProduct <= _amountOfProduction; ++currentProduct)
            {
                aluminum.Add(new Aluminum());
                copper.Add(new Copper());
                quartz.Add(new Quartz());
            }
            var i = 0;
            
            List<CPU> cpu = new List<CPU>();

            i = 0;
            while (i != aluminum.Count)
            {
                cpu.Add(new CPU(aluminum[i], copper[i]));
                i++;
            }

            /*foreach (var al in aluminum)
            {
                foreach (var cu in copper)
                {
                    cpu.Add(new CPU(al, cu));
                }
            }*/

            List<GPU> gpu = new List<GPU>();

            i = 0;
            while (i != aluminum.Count)
            {
                gpu.Add(new GPU( copper[i], quartz[i]));
                i++;
            }
            /*foreach (var cu in copper)
            {
                foreach (var qu in quartz)
                {
                    gpu.Add(new GPU(cu, qu));
                }
            }*/

            List<Monitor> monitor = new List<Monitor>();

            i= 0;
            while (i != aluminum.Count)
            {
                monitor.Add(new Monitor(aluminum[i],copper[i],quartz[i]));
                i++;
            }
            /*foreach (var al in aluminum)
            {

                foreach (var cu in copper)
                {
                    foreach (var qu in quartz)
                    {
                        monitor.Add(new Monitor(al, cu, qu));
                    }
                }
            }*/

            return new List<object>() { cpu, gpu, monitor };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    sealed class Trading  //торговля
    {
        private List<object> _devices;
        private Company _company;
        private decimal SumDevices = 0;
        private List<Company> _companies;
        
        public Trading(List<object> devices, Company company) 
        {
            _devices = devices;
            _company = company;
        }

        public Trading(List<object> devices, List<Company> companies)
        {
            _devices = devices;
            _companies = companies;
        }

        public Trading(List<object> devices, int ID_company)
        {
            _devices = devices;
            _companies = new CollectionCompany(1).GetCompaniesById(ID_company);
        }

        public Trading(List<object> devices, List<int> IDs_companies) // TODO. Исправить множественную продажу
        {
            _devices = devices;
            _companies = new CollectionCompany(0).GetCompaniesById(IDs_companies);
        }

        public void Trade() 
        {
            foreach (var collections in _devices)
            {
                if (collections is List<CPU>)
                {
                    var tmp = collections as List<CPU>;
                    for (int i = 0; i < tmp.Count; ++i) 
                    {
                        SumDevices += (tmp[i].CostAL + tmp[i].CostCU);
                    }
                }
                else if (collections is List<GPU>)
                {
                    var tmp = collections as List<GPU>;
                    for (int i = 0; i < tmp.Count; ++i)     
                    {
                        SumDevices += tmp[i].CostCU + tmp[i].CostQU;
                    }
                }
                else if (collections is List<Monitor>)
                {

                    var tmp = collections as List<Monitor>;
                    for (int i = 0; i < tmp.Count; ++i) 
                    {
                        SumDevices += (tmp[i].CostAL + tmp[i].CostCU + tmp[i].CostQU);
                    }
                }
            }

            if(_company != null)
            {
                if (_company.Bankrot != true)
                {
                    _company.Price -= SumDevices;
                    NameCompany(_company);
                }
            }

            else if (_companies != null)
            {
                foreach(var companyInList in _companies)
                {
                    if (companyInList.Bankrot != true) 
                    {
                        companyInList.Price -= SumDevices;
                    }
                }
                NameCompany(_companies);
            }
        }
        private static void NameCompany(Company company) 
        {
            Console.WriteLine($"Продукт был продан  { company.Name}");
            Console.WriteLine($"Цена {company.Price}");
        }
        private static void NameCompany(List<Company>companies)
        {   
            foreach(var company in companies) 
            { 
            Console.WriteLine($"Продукт был продан  { company.Name}");
            Console.WriteLine($"Цена {company.Price}");
            }
        }
        

        public void printCost() => Console.WriteLine(SumDevices);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roman.BaseAbstracts;


namespace Roman
{
    sealed class Company : BaseCompany
    {
        private string _address;

        public Company(string name, decimal price, string address) : base(name, price) 
        {
            _address = address;
        }

        public override void GetInformationCompany()
        {
            Console.WriteLine($"Name: {_name}, Cost: {_price}, Address: {_address}");
        }
    }
}

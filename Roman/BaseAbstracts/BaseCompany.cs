using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roman.Service;

namespace Roman.BaseAbstracts
{
    abstract class BaseCompany
    {
        protected int _id { get; private set; }
        protected string _name { get; private set; }
        protected decimal _price { get; private set; }
        protected bool _bankrot { get; private set; }

        //private List<int> ListIDs = GenerationHelper.GenerateListId(5); // Убрано 05.10.2021, чтобы создавать новую коллекцию компаний
        private static int indexCompany;

        public string Name
        { get { return _name; } }

        public decimal Price
        { get { return _price; } set { if (value < 0) { Console.WriteLine("Отрицательный баланс"); } else { _price = value; } } }

        public bool Bankrot
        { get { return _bankrot; } set { _bankrot = value; } }

        public int Id { get { return _id; } }

        public BaseCompany(string name, decimal money)
        {
            //_id = ListIDs[indexCompany]; // Убрано 05.10.2021, чтобы создавать новую коллекцию компаний
            _id = GenerationHelper.GenerateListId(1)[0];
            _name = name;
            _price = money;
            _bankrot = false;

            ++indexCompany;
        }

        public virtual void GetInformationCompany()
        {
            Console.WriteLine($"Name: {_name}, Cost: {_price}");
        }

    }
}

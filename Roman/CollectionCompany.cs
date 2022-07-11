using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    class CollectionCompany
    {
        private enum Status
        {
            NOT_FOUNDED_COMPANY,
            FOUNDED_COMPANY
        }

        private static readonly Random _random = new Random();
        private static List<Company> _companies = new List<Company>();

        public List<Company> Companies { get { return _companies; } }

        public CollectionCompany()
        {
            _companies = new List<Company>();
        }

        public CollectionCompany(int AmountOfCompany)
        {
            _companies = GenerateCompany(AmountOfCompany);
        }

        public List<Company> GetCompaniesById(int IDs_company)
        {
            List<Company> LCompany = new List<Company>();

            foreach(var company in _companies)
            {
                if(company.Name == FindCompanyById(IDs_company))
                {
                    LCompany.Add(company);
                    break;
                }
            }

            return LCompany;
        }

        public List<Company> GetCompaniesById(List<int> IDs_companies)
        {
            List<Company> LCompany = new List<Company>();

            for (int index = 0; index < IDs_companies.Count; ++index)
            {
                foreach (var company in _companies)
                {
                    if (company.Name == FindCompanyById(IDs_companies[index]))
                    {
                        LCompany.Add(company);
                        break;
                    }
                }
            }

            return LCompany;
        }

        private List<Company> GenerateCompany(int AmountOfCompany)
        {
            for(int currentIndex = 0; currentIndex < AmountOfCompany; ++currentIndex)
            {
                _companies.Add(new Company($"CompanyName{currentIndex + 1}", _random.Next(0, 1000000), $"Address_{currentIndex}"));
            }

            return _companies;
        }

        public string FindCompanyById(int id)
        {
            foreach(var elem in _companies)
            {
                if (elem.Id == id)
                {
                    return elem.Name;
                }
            }
            return null;
        }

        public int FindCompanyByName(string name)
        {
            foreach (var elem in _companies)
            {
                if (elem.Name == name)
                {
                    return elem.Id;
                }
            }
            return (int)Status.NOT_FOUNDED_COMPANY;
        }
    }
}

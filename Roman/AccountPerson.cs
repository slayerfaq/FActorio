using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    class AccountPerson
    {
        private string _login;
        private string _password;
        private bool _isAuthorized;
        private List<int> _IDs_Company;

        public string Login { get { return _login; } }
        public string Password { get { return _password; } }
        public bool IsAuthorized { get { return _isAuthorized; } }
        public List<int> IDs_Company { get { return _IDs_Company; } }

        public AccountPerson(string login, string password)
        {
            _login = login;
            _password = password;
            _isAuthorized = false;

            _IDs_Company = new List<int>();
        }

        public void ChangeStateActivity()
        {
            _isAuthorized = !_isAuthorized;
        }

        public void ShowBindingCompanies()
        {
            List<Company> companies = new CollectionCompany(5).Companies;
            foreach(var elem in companies)
            {
                _IDs_Company.Add(elem.Id);
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roman.Service.Interfaces;

namespace Roman.Service
{
    class AuthorizationHelper : IAuthRegHelper
    {
        private string _login;
        private string _password;
        private bool IsAuthorizate = false;
        private string _pathToUserFile = "Users.txt";
        private (List<string>, List<string>) originalPairLoginPassword;

        public AuthorizationHelper() 
        {
            originalPairLoginPassword = ReadDataUsers();
        }

        public (List<string>, List<string>) ReadDataUsers()
        {
            List<string> _login = new List<string>();
            List<string> _password = new List<string>();
            (List<string>, List<string>) _turple = (_login, _password);

            foreach (var elem in File.ReadAllText(_pathToUserFile).Replace("\r\n", ".").Split('.'))
            {
                try
                {
                    _login.Add(elem.Split(':')[0]);
                    _password.Add(elem.Split(':')[1]);
                }
                catch(Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }

            return _turple;
        }

        public bool CheckAbsent(string currentLogin, string currentPassword)
        {
            List<string> Logins = originalPairLoginPassword.Item1;
            List<string> Passwords = originalPairLoginPassword.Item2;

            for (int index = 0; index < Logins.Count; ++index)
            {
                if (currentLogin == Logins[index] && currentPassword == Passwords[index])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckAbsent(AccountPerson accountPerson)
        {
            List<string> Logins = originalPairLoginPassword.Item1;
            List<string> Passwords = originalPairLoginPassword.Item2;

            for (int index = 0; index < Logins.Count; ++index)
            {
                if (accountPerson.Login == Logins[index] && accountPerson.Password == Passwords[index])//ошибка если нажимать все время пробел
                {
                    return true;
                }
            }

            return false;
        }

        List<string[]> IAuthRegHelper.ReadDataUsers()
        {
            throw new NotImplementedException();
        }
    }
}

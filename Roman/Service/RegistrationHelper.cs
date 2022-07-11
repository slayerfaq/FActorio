using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roman.Service.Interfaces;

namespace Roman.Service
{
    class RegistrationHelper : IAuthRegHelper
    {
        private string _login;
        private string _password;
        private string _pathToUserFile = "Users.txt";

        public string Login { get { return _login; } }
        public string Password { get { return _password; } }

        public RegistrationHelper(string login)
        {
            _login = login;
            _password = GetRandomPassword();

            AddRecordNewUser();
        }

        public RegistrationHelper(string login, string password) : this(login)
        {
            _password = password;
            AddRecordNewUser();
        }

        private string GetRandomPassword(int LenghtRandomString = 5)
        {
            string randomStr = string.Empty;
            int a = 48, b = 122;

            Random r = new Random();
            while (randomStr.Length < LenghtRandomString)
            {
                Char c = (char)r.Next(a, b);
                if (Char.IsLetterOrDigit(c))
                    randomStr += c;
            }
            return randomStr;
        }

        private void AddRecordNewUser()
        {
            bool IsDublicate = false;
            var UsersData = ReadDataUsers();
            if (UsersData is not null)
            {
                foreach (var t in UsersData)
                {
                    if (t[0] == _login)
                    {
                        IsDublicate = true;
                        break;
                    }
                }
                if (File.Exists(_pathToUserFile))
                {
                    if (IsDublicate == false)
                    {
                        File.AppendAllText(_pathToUserFile, $"{_login}:{_password}\r\n");
                    }
                    else {
                        Console.WriteLine("Login is already exist");
                    }
                }

                else
                {
                    Console.WriteLine("File not found");
                }
            }
        }

        public List<string[]> ReadDataUsers()
        {
            /*List<string[]> userPair = new List<string[]>();*/
            List<string[]> _login = new List<string[]>();
            List<string[]> _password = new List<string[]>();

            foreach(var elem in File.ReadAllText(_pathToUserFile).Replace("\r\n", ".").Split('.'))
            {
                _login.Add(elem.Split(':'));
            }

            return _login;
        }
    }
}

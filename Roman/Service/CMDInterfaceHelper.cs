using System;
using System.Collections.Generic;

namespace Roman.Service
{
    static class CMDInterfaceHelper
    {
        static private void InterFace() => Console.WriteLine("a - auth, r - registration, e - exit, q - quit, t - list\n");
        static private AccountPerson AccountAuth()
        {
            Console.Write("\nВведите логин -> ");
            string login = Console.ReadLine();
            Console.Write("\nВведите пароль -> ");
            string password = Console.ReadLine();

            AccountPerson accountPerson = new AccountPerson(login, password);
            return accountPerson;
        }
        static private void AccountReg() 
        {
            Console.Write("\nВведите логин:");
            string text = Console.ReadLine();
            RegistrationHelper registrationHelper = new RegistrationHelper(text);
            Console.WriteLine($"Login: {registrationHelper.Login}, Password: {registrationHelper.Password}");
        }
        static private void ListTrading()
        {
            List<object> devices = new Factory(5).Collector();
            List<Company> companies = new CollectionCompany(5).Companies;

            Trading trading = new Trading(devices, companies[0]);
            trading.Trade();
            trading.printCost();

            Trading trading_two = new Trading(devices, companies);
            trading_two.Trade();
            trading_two.printCost();
        }
        static private void ListTrading(AccountPerson IDs_companies)
        {
            List<object> devices = new Factory(5).Collector();
            List<Company> companies = new CollectionCompany().Companies;

            Trading trading = new Trading(devices, IDs_companies.IDs_Company[0]);
            trading.Trade();
            trading.printCost();

            Trading trading_two = new Trading(devices, IDs_companies.IDs_Company); // TODO. Исправить множественную продажу
            trading_two.Trade();
            trading_two.printCost();
        }
        static public void HardWorkingProcess()
        {
            InterFace();
            Console.Write("Введите команду a/r -> ");
            ConsoleKeyInfo action = Console.ReadKey();
            do
            {
                switch (action.KeyChar)
                {
                    case 'h':
                        {
                            InterFace();
                            break;
                        }
                    case 'a':
                        {
                            var accountPerson = AccountAuth();
                            bool IsAuthorized = new AuthorizationHelper().CheckAbsent(accountPerson);
                            if (IsAuthorized)
                            {
                                Console.WriteLine("Вы успешно авторизовались");
                                accountPerson.ChangeStateActivity();
                                accountPerson.ShowBindingCompanies();
                                ConsoleKeyInfo actionAuth = Console.ReadKey();
                                do
                                {
                                    switch (actionAuth.KeyChar)
                                    {
                                        case 't':
                                            {
                                                ListTrading(accountPerson);
                                                Console.ReadLine();
                                                break;
                                            }
                                        case 'e':
                                            {
                                                Console.Write("\nВы хотите выйти из аккаунта? -> y/n\n");
                                                if ("y" == Console.ReadLine())
                                                {
                                                    IsAuthorized = false;
                                                    Console.Clear();
                                                    Console.WriteLine("\nВы вышли из аккаунта press Enter");
                                                    accountPerson.ChangeStateActivity();
                                                }
                                                break;
                                            }
                                        default: { Console.WriteLine("\nТакой команды нет"); break; }
                                    }
                                    actionAuth = Console.ReadKey();
                                } while (accountPerson.IsAuthorized);
                            }
                            else
                            {
                                Console.WriteLine("Неправильно введен логин/пароль");
                            }
                            break;
                        }
                    case 'r':
                        {
                            AccountReg();
                            break;
                        }
                    default: { Console.WriteLine("\nТакой команды нет"); break; }
                }
                Console.Write("Введите команду a/r ->\n ");
                action = Console.ReadKey();
            } while (action.KeyChar != 'q');
        }
    }
}

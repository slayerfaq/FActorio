using System;

namespace Roman
{
    class Program
    {
        static void Main(string[] args)
        {
            //CMDInterfaceHelper.HardWorkingProcess();

            try
            {
                DataBaseManager dbm = new DataBaseManager();
                /*Console.Write("Введите название таблицы: ");
                string table_name = Console.ReadLine();
                dbm.SelectTableOnNameTable(table_name);*/

                /*List<string> tables = new List<string>() { "Company", "Components", "Factory", "Materials", "Users_Trading" };
                foreach (var table in tables)
                
                Console.WriteLine($"table: {table} {dbm.GetIdAnyTable(table)}");
                //Console.ReadLine("fsafas");

                Console.WriteLine(dbm.MaterialsDB(1,"Test"));

                Console.WriteLine(dbm.CompanyDB("Test"));

                Console.WriteLine(dbm.FactoryDB("Test", 1, 1));
                
                Console.WriteLine(dbm.ComponentsDB( "Test", 1, 1));
            
                Console.WriteLine(dbm.Users_TradingDB("Test", "test","test","test", 1, 1));
                //Console.WriteLine($"tables: { dbm.GetTable()}");*/

                /*List<string> params_data = new List<string>() { "Login", "Password", "idFactory" };
                Console.WriteLine("------------------------------------------------------------");
                var obj = dbm.GetDataFromAnyTable("SELECT `Login`, `Password`, `idFactory` FROM `Users_Trading`", params_data);

                foreach (var elem in obj)
                {
                    string output_data = null;
                    for(int index = 0; index < ((List<string>)elem).Count; ++index)
                    {
                        output_data += $"{params_data[index]}: {((List<string>)elem)[index]} ";
                    }
                    Console.WriteLine(output_data);
                }
                Console.WriteLine("------------------------------------------------------------");*/

                /*if (dbm.InsertDataToAnyTable("Company", new List<string>() { "idCompany", "Name_Company" }, new List<string>() { "8", "NameTestInsert" }) > 0)
                {
                    Console.WriteLine("Inserted");
                }*/
                /*XML_Parser XML_Parser = new XML_Parser();
                var data = XML_Parser.ReadXML();

                if (dbm.InsertDataToAnyTable(data) > 0)
                {
                    Console.WriteLine("Inserted");
                }*/
                dbm.DeleteAnyData("Components", "Test2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}



using MySql.Data.MySqlClient;
using Roman.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Roman
{
    class DataBaseManager
    {
        MySqlConnection MySQLConnection;

        public DataBaseManager()
        {
            MySQLConnection = GetDBConnection();
        }

        public DataBaseManager(string host, int port, string database, string username, string password, string charset)
        {
            MySQLConnection = GetDBConnection(host, port, database, username, password, charset);
        }

        public static MySqlConnection GetDBConnection()
        {
            //host, port, database, username, password, charset
            List<string> Options = new List<string> { "mysql.100ws.com", "3306", "facfac512_factory", "facfac512_factory", "12345678!", "utf8" };

            return GetDBConnection(Options[0], Convert.ToInt32(Options[1]), Options[2], Options[3], Options[4], Options[5]);
        }

        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password, string charset)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";charset=" + charset;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public int GetIdAnyTable(string name_table)
        {
            int result = 0;
            string query = $"SELECT count(*) as id FROM {name_table}";
            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Connection.Open();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Convert.ToInt32(reader["id"]);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return result;
        }
        public int CompanyDB(string name)
        {
            int resultOfNewData = 0;
            string query = $"INSERT INTO `Company` (idCompany, Name_Company) VALUES ({GetIdAnyTable("Materials") + 1},'{name}')";

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return resultOfNewData;
        }
        public int ComponentsDB(string name_components, int count, int id_factory)
        {
            int resultOfNewData = 0;
            string query = $"INSERT INTO `Components` (idComponents, Name_Components, Count_Components, idFactory) VALUES ({GetIdAnyTable("Components") + 1},'{name_components}', {count}, {id_factory})";

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return resultOfNewData;
        }
        public int FactoryDB(string name_factory, int id_material, int id_company)
        {
            int resultOfNewData = 0;
            string query = $"INSERT INTO `Factory` (idFactory, Name_Factory, idMaterials, idCompany) VALUES ({GetIdAnyTable("Factory") + 1}, '{name_factory}', {id_material}, {id_company})";

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return resultOfNewData;
        }
        public int MaterialsDB(int count, string name)
        {
            int resultOfNewData = 0;
            string query = $"INSERT INTO `Materials` (idMaterials, Count_Material, Name_Material) VALUES ({GetIdAnyTable("Materials") + 1}, {count},'{name}')";

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return resultOfNewData;
        }
        public int Users_TradingDB(string login, string password, string user_email, string user_role, int id_factory, int id_company)
        {
            int resultOfNewData = 0;
            string query = $"INSERT INTO `Users_Trading` (idUsers, Login, Password, User_role, User_Email, idFactory, idCompany) VALUES ({GetIdAnyTable("Users_Trading") + 1}, '{login}', '{password}','{user_role}' ,'{user_email}',{id_factory},{id_company})";

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return resultOfNewData;
        }
        /*public string GetTable(string name_table)
        {
            int result = 0;
            string query = $"SELECT * FROM [Company], [Components], [Factory], [Materials], [Users_Trading]";
            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Connection.Open();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Convert.ToInt32(reader[name_table]);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return query;
        }*/
        /*public string GetTable(string name_table) 
        {
            string query = $"SELECT * FROM [Company], [Components], [Factory], [Materials], [Users_Trading]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, DbConnection);
        }*/
        public List<object> GetDataFromAnyTable(string query, List<string> output_params)
        {
            List<object> data = new List<object>();
            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<string> DBdata = new List<string>();
                        if (output_params != null)
                        {
                            foreach (var param in output_params)
                            {
                                DBdata.Add(reader[param].ToString());
                            }
                        }
                        else
                        {
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                DBdata.Add(reader.GetValue(i).ToString());
                            }
                        }
                        data.Add(DBdata);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return data;
        }
        public void SelectTableOnNameTable(string table_name)
        {
            switch (table_name)
            {
                case "Company":
                    {
                        var obj = GetDataFromAnyTable("SELECT * FROM `Company`", null);
                        foreach (var elem in obj)
                        {
                            string output_data = null;
                            for (int index = 0; index < ((List<string>)elem).Count; ++index)
                            {
                                output_data += $"{((List<string>)elem)[index]} ";
                            }
                            Console.WriteLine(output_data);
                        }
                        break;
                    }
                case "Components":
                    {
                        var obj = GetDataFromAnyTable("SELECT * FROM `Components`", null);
                        break;
                    }
                case "Factory":
                    {
                        var obj = GetDataFromAnyTable("SELECT * FROM `Factory`", null);
                        break;
                    }
                case "Materials":
                    {
                        var obj = GetDataFromAnyTable("SELECT * FROM `Materials`", null);
                        break;
                    }
                case "Users_Trading":
                    {
                        var obj = GetDataFromAnyTable("SELECT * FROM `Users_Trading`", null);
                        break;
                    }
                default: { Console.WriteLine($"Таблицы {table_name} не существует"); break; }
            }
        }

        // Реализовать возможность вставки в БД любого кол-ва данных (вложенный цикл)
        // Дополнительно: данные берутся из XML-файла и выгружаются в него
        public int InsertDataToAnyTable(string table_name, List<string> input_params, List<string> input_values)
        {
            string query = $"INSERT INTO `{table_name}` (";
            for (int index = 0; index < input_params.Count - 1; ++index)
            {
                query += $"`{input_params[index]}`, ";
            }
            query += $"`{input_params[input_params.Count - 1]}`) VALUES (";
            for (int index = 0; index < input_params.Count - 1; ++index)
            {
                query += $"'{input_values[index]}', ";
            }
            query += $"'{input_values[input_values.Count - 1]}');";

            int resultOfNewData = 0;

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return resultOfNewData;
        }

        //TODO доработать InputValues (396-401), реализовать через int index_Value = 0;
        public int InsertDataToAnyTable(XML_Data xml_data)
        {
            string query = string.Empty;
            int index_table = 0;

            foreach (var col in xml_data.InputValues)
            {
                foreach (var row in xml_data.InputParams)
                {
                    query += $"INSERT INTO `{xml_data.TableName[index_table]}` (";
                    for (int index = 0; index < row.Count; ++index)
                    {
                        query += $"`{row[index]}`, ";
                    }

                    query += $"`{xml_data.InputParams[xml_data.InputParams.Count - 1][xml_data.InputParams[xml_data.InputParams.Count - 1].Count - 1]}`) VALUES (";

                    for (int index = 0; index < col.Count; ++index)
                    {
                        query += $"'{col[index]}', ";
                    }

                    query += $"'{xml_data.InputValues[xml_data.InputValues.Count - 1][xml_data.InputValues[xml_data.InputValues.Count - 1].Count - 1]}');";
                    index_table++;
                }
            }

            int resultOfNewData = 0;

            MySqlConnection conn = GetDBConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                resultOfNewData = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


            return resultOfNewData;
        }

        public void DeleteAnyData(string TableName, string Data)
        {
            List<string> names = new List<string>() { "Name_Material", "Name_Factory", "Name_Company", "Name_Components", "Login" };
            //string test2 = TableName.Substring(0, 5);
            string test2 = "Components";
            .int test = names.IndexOf(test2);

            string query = $"DELETE FROM {TableName} WHERE {names} ";

            MySqlConnection conn = GetDBConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Connection.Open();

                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine($"было удалено {row} записей");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}



using System;
using System.Collections.Generic;
using System.Configuration;
using tryLINQ.Classes;
using System.Data.SqlClient;
using System.Windows;

namespace tryLINQ.Db
{
    public class QueryDb
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnect"].ToString();

        public List<Pers> SelectPers(string query)
        {
            List<Pers> listPersons = new List<Pers>();
            SqlConnection connect = new SqlConnection(connectionString);
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = query; 
                command.Connection = connect;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader.GetValue(0));
                        string name = Convert.ToString(reader.GetValue(1));
                        string lastName = Convert.ToString(reader.GetValue(2));
                        int age = Convert.ToInt32(reader.GetValue(3));
                        string phone = Convert.ToString(reader.GetValue(4));
                        string language = Convert.ToString(reader.GetValue(5));

                        listPersons.Add(new Pers(id, name, lastName, phone, age, language));
                    };
                }
                else
                    listPersons = null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                listPersons = null;
            }
            finally
            {
                connect.Close();
            }
            
            return listPersons;
        }
        public bool CreateAndUpdatePers(string query)
        {
            bool result = false;
            SqlConnection connect = new SqlConnection(connectionString);
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connect;
                try
                {
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Invalid string length\r\n{ex.Message}", "Exception");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
            finally
            {
                connect.Close();
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_Нечеухин
{
    public class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-57HE20H\SQLEXPRESS;Initial Catalog=Практика_Нечеухин;Integrated Security=True");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            { 
            connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}

using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class SqlDataAccess : ISqlDataAccess
    {
        private string connectionString = "server=localhost;port=3306;uid=appDev;pwd=AppDev;database=db_garage;";
        //this rads data from the DB
        public List<T> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = connection.Query<T>(sql, parameters);
                return data.ToList();
            }
        }

        public void SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection= new MySqlConnection(connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }

        //save is equivalent to changing/adding/deleting
    }
}

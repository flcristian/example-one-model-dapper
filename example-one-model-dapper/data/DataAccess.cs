using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.data
{
    public class DataAccess : IDataAccess
    {
        public List<T> LoadData<T, U>(String sqlStatement, U parameters, String connectionString)
        {

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();

                return rows;

            }
        }

        public void SaveData<T>(String sqlStatement, T parameters, String connectionString)
        {

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

                connection.Execute(sqlStatement, parameters);

            }
        }

    }
}

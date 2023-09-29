using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.data
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(String sqlStatement, U parameters, String connectionString);

        void SaveData<T>(String sqlStatement, T parameters, String connectionString);

    }
}

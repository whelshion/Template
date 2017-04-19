using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Repository
{
    public class DbFactory
    {
        private IDbConnection CreateConnection<T>() where T : IDbConnection, new()
        {
            IDbConnection connection = new T();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Template"].ToString();
            connection.Open();
            return connection;
        }

        public IDbConnection CreateSqlConnection()
        {
            return CreateConnection<SqlConnection>();
        }
    }
}

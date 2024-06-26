using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_
{
    public class DatabaseService :IDisposable
    {
        private readonly IDbConnection _db;

        public DatabaseService(string connectionString)
        {
            _db= new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()=> _db;

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}

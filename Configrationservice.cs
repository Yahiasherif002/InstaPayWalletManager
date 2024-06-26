using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_
{
    public class Configrationservice
    {
        public IConfiguration Configuration { get; }

        public Configrationservice()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.json")
            .Build();
        }

        public string GetConnectionString(string connectionString)
        {
            return Configuration.GetConnectionString(connectionString);
        }

    }
}

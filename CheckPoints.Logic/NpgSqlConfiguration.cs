using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoints.Logic
{
    class NpgSqlConfiguration : DbConfiguration
    {
        public NpgSqlConfiguration()
        {
            var name = "Npgsql";

            SetProviderFactory(name, NpgsqlFactory.Instance);

            SetProviderServices(name, NpgsqlServices.Instance);

            SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
        }
    }
}

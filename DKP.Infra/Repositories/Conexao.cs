using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;

namespace DKP.Infra.Repositories
{
    public class DbConnect
    {
        public static SqlConnection Connection => new SqlConnection(ConnectionString);
        public static string ConnectionString => configuration.GetConnectionString("DKP");

        static IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();       
    }
}

using System.Data.SqlClient;

namespace DKP.Infra.Repositories
{
    public class DbConnect
    {
        public static SqlConnection Connection => new SqlConnection(ConnectionString);

        public static string ConnectionString
        {
            get
            {
                return $@"Server=LAPTOP-MPDEFR5C\SQLEXPRESS; Database=CrudEmpresa; persist security info=True; Integrated Security=SSPI;";
            }
        }
    }
}

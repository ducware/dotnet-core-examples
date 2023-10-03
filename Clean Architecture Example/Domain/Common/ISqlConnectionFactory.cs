using Microsoft.Data.SqlClient;

namespace Domain.Common
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}

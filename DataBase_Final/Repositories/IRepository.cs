using Microsoft.Data.SqlClient;

namespace DataBase_Final.Repositories
{
    interface IRepository 
    {       
        SqlConnection ConnOpen();

        void ConnClose(SqlConnection Conn);
    }
}

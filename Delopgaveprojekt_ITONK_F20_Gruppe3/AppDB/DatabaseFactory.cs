using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AppDB
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private const string sqlConnectionString = "server=localhost; database=haandvaerkerdb;";
        private SqlConnection con = new SqlConnection(sqlConnectionString);

        public IDatabase GetDatabase()
        {
            con.Open();

            return new Database(con);
        }
    }

}

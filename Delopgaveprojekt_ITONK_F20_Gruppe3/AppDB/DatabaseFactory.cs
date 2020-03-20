using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AppDB
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private SqlConnection con = new SqlConnection(Constants.sqlConnectionString); //Missing connection string in constants folder & missing constants folder

        public IDatabase GetDatabase()
        {
            con.Open();

            return new Database(con);
        }
    }

}

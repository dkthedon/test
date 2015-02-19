using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuestionPortal.DAL
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnectionObject()
        {
            return new SqlConnection(Database.ConnectionString);
        }
    }
}

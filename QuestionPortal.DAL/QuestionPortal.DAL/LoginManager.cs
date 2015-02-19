using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPortal.DAL
{
    public struct Login
    {
        public int ID;
        public string UserName;
        public string Password;
    }
    public static class LoginManager
    {
        public static User GetLogin(Login login)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetLogin";
                cmd.Parameters.AddWithValue("@username", login.UserName);
                cmd.Parameters.AddWithValue("@password", login.Password);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    User user = new User();
                    while (dataReader.Read())
                    {
                        user.ID = (int)dataReader["ID"];
                        user.Name = dataReader["name"] as string;
                        user.Email = dataReader["email"] as string;
                    }
                    return user;
                }
            }
        }
    }
}

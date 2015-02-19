using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuestionPortal.DAL
{
    public struct User
    {
        public int ID;
        public string Name;
        public string Email;
        public string UserName;
        public string Password;
    }

    public static class UserManager
    {
        public static User GetUser(int id)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetUser";
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    dataReader.Read();
                    return ReadUser(dataReader);
                }
            }
        }

        public static User ReadUser(SqlDataReader dataReader)
        {
            User user = new User();
            user.Email = dataReader["email"] as string;
            user.Name = dataReader["name"] as string;
            user.ID = (int)dataReader["ID"];
            return user;
        }

        public static bool DeleteUser(int id)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteUser";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static bool UpdateUser(User user)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUser";
                cmd.Parameters.AddWithValue("@id", user.ID);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static bool InsertUser(User user)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddUser";
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> listOfUsers = new List<User>();
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllUsers";
                using(SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        User user = new User();
                        user.ID = (int)dataReader["ID"];
                        user.Name = dataReader["name"] as string;
                        user.Email = dataReader["email"] as string;
                        listOfUsers.Add(user);
                    }
                }
            }

            return listOfUsers;
        }
    }
}

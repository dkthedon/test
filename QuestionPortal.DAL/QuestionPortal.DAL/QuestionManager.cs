using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuestionPortal.DAL
{
    public struct Question
    {
        public int ID;
        public string question;
        public int PostedBy;
        public string UserName;
        public string UserEmail;
    }
    public static class QuestionManager
    {
        public static Question GetQuestion(int id)
        {
            Question question = new Question();
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ReadQuestion";
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        question = ReadQuestion(dataReader);
                    }
                }
            }

            return question;
        }

        public static bool DeleteQuestion(int id)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteQuestion";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(SqlException)
                {
                    return false;
                }
            }
        }

        public static Question ReadQuestion(SqlDataReader dataReader)
        {
            Question question;
            question.ID = (int)dataReader["ID"];
            question.question = dataReader["question"] as string;
            question.UserName = dataReader["name"] as string;
            question.UserEmail = dataReader["email"] as string;
            question.PostedBy = (int)dataReader["postedBy"];
            return question;
        }

        public static bool InsertQuestion(Question question)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddQuestion";
                cmd.Parameters.AddWithValue("@question", question.question);
                cmd.Parameters.AddWithValue("@postedBy", question.PostedBy);
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

        public static bool UpdateQuestion(Question question)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateQuestion";
                cmd.Parameters.AddWithValue("@question", question.question);
                cmd.Parameters.AddWithValue("@id", question.ID);
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

        public static List<Question> GetAllQuestions()
        {
            List<Question> listOfQuestions = new List<Question>();
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllQuestions";
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listOfQuestions.Add(ReadQuestion(dataReader));
                    }
                }
            }

            return listOfQuestions;
        }

        public static List<Question> GetUserQuestions(int id)
        {
            List<Question> listOfUserQuestions = new List<Question>();
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetUserQuestions";
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listOfUserQuestions.Add(ReadQuestion(dataReader));
                    }
                }
            }

            return listOfUserQuestions;
        }
    }
}

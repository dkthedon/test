using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuestionPortal.DAL
{
    public struct Answer
    {
        public int ID;
        public string answer;
        public string UserName;
        public string UserEmail;
        public int PostedBy;
        public int QuestionId;
    }

    public static class AnswerManager
    {
        public static Answer GetAnswer(int id)
        {
            Answer answer = new Answer();
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAnswer";
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        answer = ReadAnswer(dataReader);
                    }
                }
            }
            return answer;
        }

        public static Answer ReadAnswer(SqlDataReader dataReader)
        {
            Answer answer = new Answer();
            answer.answer = dataReader["answer"] as string;
            answer.ID = (int)dataReader["ID"];
            answer.PostedBy = (int)dataReader["postedBy"];
            answer.QuestionId = (int)dataReader["questionId"];
            answer.UserEmail = dataReader["email"] as string;
            answer.UserName = dataReader["name"] as string;
            return answer;
        }

        public static bool DeleteAnswer(int id)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAnswer";
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

        public static bool InsertAnswer(Answer answer)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddAnswer";
                cmd.Parameters.AddWithValue("@answer", answer.answer);
                cmd.Parameters.AddWithValue("@postedBy", answer.PostedBy);
                cmd.Parameters.AddWithValue("@questionId", answer.QuestionId);
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

        public static bool UpdateAnswer(Answer answer)
        {
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAnswer";
                cmd.Parameters.AddWithValue("@answer", answer.answer);
                cmd.Parameters.AddWithValue("@id", answer.ID);
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

        public static List<Answer> GetAnswers(int questionId)
        {
            List<Answer> listOfAnswers = new List<Answer>();
            SqlConnection conn = DatabaseConnection.GetConnectionObject();
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAnswers";
                cmd.Parameters.AddWithValue("@questionId", questionId);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listOfAnswers.Add(ReadAnswer(dataReader));
                    }
                }
            }
            
            return listOfAnswers;
        }
    }
}

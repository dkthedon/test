using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public static class QuestionList
    {
        public static List<Question> GetAllQuestions()
        {
            List<Question> listOfQuestions = new List<Question>();
            List<DAL.Question> list = QuestionManager.GetAllQuestions();
            foreach (var question in list)
            {
                listOfQuestions.Add(Question.ReadQuestion(question));
            }

            return listOfQuestions;
        }

        public static List<Question> GetUserQuestions(int id)
        {
            List<Question> listOfUserQuestions = new List<Question>();
            List<DAL.Question> list = DAL.QuestionManager.GetUserQuestions(id);
            foreach (var question in list)
            {
                listOfUserQuestions.Add(Question.ReadQuestion(question));
            }

            return listOfUserQuestions;
        }
    }
}

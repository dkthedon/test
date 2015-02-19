using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public static class AnswerList
    {
        public static List<Answer> GetAnswers(int questionId)
        {
            List<Answer> listOfAnswers = new List<Answer>();
            List<DAL.Answer> list = new List<DAL.Answer>();
            list = AnswerManager.GetAnswers(questionId);
            foreach (var answer in list)
            {
                listOfAnswers.Add(Answer.FetchAnswer(answer));
            }

            return listOfAnswers;
        }
    }
}

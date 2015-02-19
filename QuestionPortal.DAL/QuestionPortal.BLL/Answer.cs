using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public class Answer
    {
        private int id;
        private string answer;
        private int postedBy;
        private int questionId;
        private string userName;
        private string userEmail;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string AnswerString
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }

        public int QuestionId
        {
            get
            {
                return questionId;
            }
            set
            {
                questionId = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            set
            {
                userEmail = value;
            }
        }

        public int PostedBy
        {
            get
            {
                return postedBy;
            }
            set
            {
                postedBy = value;
            }
        }

        public static Answer GetAnswer(int id)
        {
            DAL.Answer answer = AnswerManager.GetAnswer(id);
            return FetchAnswer(answer);
        }

        internal static Answer FetchAnswer(DAL.Answer answer)
        {
            Answer fetchedAnswer = new Answer();
            fetchedAnswer.AnswerString = answer.answer;
            fetchedAnswer.ID = answer.ID;
            fetchedAnswer.PostedBy = answer.PostedBy;
            fetchedAnswer.UserName = answer.UserName;
            fetchedAnswer.UserEmail = answer.UserEmail;
            fetchedAnswer.QuestionId = answer.QuestionId;
            return fetchedAnswer;
        }

        public static bool DeleteAnswer(int id)
        {
            return AnswerManager.DeleteAnswer(id);
        }

        public bool Save()
        {
            DAL.Answer answer = new DAL.Answer();
            answer.ID = this.ID;
            answer.answer = this.AnswerString;
            answer.QuestionId = this.QuestionId;
            answer.UserName = this.UserName;
            answer.UserEmail = this.UserEmail;
            answer.PostedBy = this.PostedBy;
            if (this.ID > 0)
            {
                return AnswerManager.UpdateAnswer(answer);
            }
            else
            {
                return AnswerManager.InsertAnswer(answer);
            }
        }
    }
}

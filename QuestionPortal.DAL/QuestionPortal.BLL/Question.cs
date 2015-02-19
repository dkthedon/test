using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public class Question
    {
        private int id;
        private string questionString;
        private int postedBy;
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

        public string QuestionString
        {
            get
            {
                return questionString;
            }
            set
            {
                questionString = value;
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

        public static Question GetQuestion(int id)
        {
            DAL.Question question = QuestionManager.GetQuestion(id);
            return ReadQuestion(question);
        }

        public static Question ReadQuestion(DAL.Question question)
        {
            Question readQuestion = new Question();
            readQuestion.ID = question.ID;
            readQuestion.QuestionString = question.question;
            readQuestion.PostedBy = question.PostedBy;
            readQuestion.UserEmail = question.UserEmail;
            readQuestion.UserName = question.UserName;
            return readQuestion;
        }

        public static bool DeleteQuestion(int id)
        {
            return QuestionManager.DeleteQuestion(id);
        }

        public bool Save()
        {
            DAL.Question question = new DAL.Question();
            question.ID = this.ID;
            question.question = this.QuestionString;
            question.PostedBy = this.PostedBy;
            question.UserName = this.UserName;
            question.UserEmail = this.UserEmail;
            if (this.ID > 0)
            {
                return QuestionManager.UpdateQuestion(question);
            }
            else
            {
                return QuestionManager.InsertQuestion(question);
            }
        }
    }
}

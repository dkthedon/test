using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public static class Login
    {

        public static User GetLogin(string username, string password)
        {
            DAL.Login login = new DAL.Login();
            login.UserName = username;
            login.Password = password;
            DAL.User user = LoginManager.GetLogin(login);
            User loggedInUser = new User();
            loggedInUser.ID = user.ID;
            loggedInUser.Name = user.Name;
            loggedInUser.Email = user.Email;
            return loggedInUser;
        }
    }
}

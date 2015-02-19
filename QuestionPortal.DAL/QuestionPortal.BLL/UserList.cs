using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public static class UserList
    {
        public static List<User> GetAllUsers()
        {
            List<User> listOfUsers = new List<User>();
            List<DAL.User> list = UserManager.GetAllUsers();
            foreach (var user in list)
            {
                listOfUsers.Add(User.ReadUser(user));
            }

            return listOfUsers;
        }
    }
}

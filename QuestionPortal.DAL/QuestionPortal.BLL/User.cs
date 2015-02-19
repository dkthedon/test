using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionPortal.DAL;

namespace QuestionPortal.BLL
{
    public class User
    {
        private int id;
        private string name;
        private string userName;
        private string email;
        private string password;

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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public static User GetUser(int id)
        {
            DAL.User user = UserManager.GetUser(id);
            return ReadUser(user);
        }

        public static User ReadUser(DAL.User user)
        {
            User readUser = new User();
            readUser.ID = user.ID;
            readUser.Name = user.Name;
            readUser.UserName = user.UserName;
            readUser.Email = user.Email;
            readUser.Password = user.Password;
            return readUser;
        }

        public static bool DeleteUser(int id)
        {
            return UserManager.DeleteUser(id);
        }

        public bool Save()
        {
            DAL.User user = new DAL.User();
            user.ID = this.ID;
            user.Name = this.Name;
            user.UserName = this.UserName;
            user.Email = this.Email;
            user.Password = this.Password;
            if (this.ID > 0)
            {
                return UserManager.UpdateUser(user);
            }
            else
            {
                return UserManager.InsertUser(user);
            }
        }
    }
}

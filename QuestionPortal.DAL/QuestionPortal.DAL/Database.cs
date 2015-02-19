using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPortal.DAL
{
    public static class Database
    {
        public static string ConnectionString
        {
            get
            {
                return "Data Source=DHARMENDRA3129; Initial Catalog=QuestionPortal; Integrated Security=true;";
            }
        }
    }
}

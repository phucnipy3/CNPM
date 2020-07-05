using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    public class BLUser
    {
        public static List<User> GetUsers()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.Where(x => x.Status).ToList();
            }
        }

        public static bool Login(string userName, string pass)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.Any(x => x.UserName == userName && x.Password == pass);
            }
        }
    }
}

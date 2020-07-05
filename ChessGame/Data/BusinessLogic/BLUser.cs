using Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Data.BusinessLogic
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
                return db.Users.Any(x => x.UserName == userName && x.Password == pass && x.Status == true);
            }
        }

        public static List<User> GetAllUser()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.ToList();
            }
        }

        public static User GetJustUser(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.Where(x => x.UserName == username).SingleOrDefault();
            }
        }

        public static void Signup(User user)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static void ChangeActive(string userName)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = db.Users.Where(x => x.UserName == userName).SingleOrDefault();
                user.Active = user.Active == true ? false : true;
                db.SaveChanges();
            }
        }

        public static void ChangePassword(string userName, string newpass)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = db.Users.Where(x => x.UserName == userName).SingleOrDefault();
                user.Password = newpass;
                db.SaveChanges();
            }
        }
    }
}

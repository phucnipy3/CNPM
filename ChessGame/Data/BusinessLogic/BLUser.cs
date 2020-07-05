﻿using Data.Entities;
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
                return db.Users.Any(x => x.UserName == userName && x.Password == pass);
            }
        }
    }
}
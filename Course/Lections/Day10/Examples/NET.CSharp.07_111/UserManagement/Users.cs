using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabrikamUserManagement
{
    public class Users
    {
        public static User GetUserById(int userId)
        {
            User result = null;

            List<User> allUsers = GetAllUsers();

            if (allUsers.Exists(user => user.UserId == userId))
            {
                result = (from users in allUsers
                          where users.UserId == userId
                          select users).Single();
            }
            return result;
        }

        private static List<User> GetAllUsers()
        {
            return new List<User>
            {
                new User(1, "Peter", "Roberts"),
                new User(2, "Eric", "Hunter"),
                new User(3, "Sam", "Williams"),
                new User(4, "Derek", "Jones")
            };
        }
    }
}
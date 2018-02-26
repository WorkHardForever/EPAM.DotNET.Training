using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabrikamUserManagement
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(int userId, string firstName, string lastName)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = string.Format("{0}.{1}", firstName, lastName);
        }
    }
}
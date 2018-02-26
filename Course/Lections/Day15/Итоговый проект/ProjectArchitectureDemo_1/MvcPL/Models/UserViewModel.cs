using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public enum Role
    {
        Administrator = 1,
        Moderator,
        User,
        Guest     
    }
    
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public Role Role { get; set; }
    }
}
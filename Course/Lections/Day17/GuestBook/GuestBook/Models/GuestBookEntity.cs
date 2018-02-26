using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class GuestBookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
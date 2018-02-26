using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class GuestBookContext:DbContext
    {
        public GuestBookContext()
            : base("GuestBookBD")
        {
        }

        public DbSet<GuestBookEntity> Entries { get; set; }
    }
}
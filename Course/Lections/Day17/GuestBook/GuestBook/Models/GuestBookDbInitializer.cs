using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class GuestBookDbInitializer : CreateDatabaseIfNotExists<GuestBookContext>
    {

        protected override void Seed(GuestBookContext context)
        {
            context.Entries.Add(new GuestBookEntity() { Id = 1, Name = "Guest 1", 
                                Message = "Hello!!!", DateAdd = DateTime.Now });
            context.Entries.Add(new GuestBookEntity() { Id = 2, Name = "Guest 2", 
                                Message = "Hello!!! Da", DateAdd = DateTime.Now });
            context.Entries.Add(new GuestBookEntity() { Id = 3, Name = "Guest 3", 
                                Message = "Hello!!! No", DateAdd = DateTime.Now });
            context.Entries.Add(new GuestBookEntity() { Id = 4, Name = "Guest 4", 
                                Message = "Hello!!! Yes", DateAdd = DateTime.Now });

            base.Seed(context);
        }
    }
}
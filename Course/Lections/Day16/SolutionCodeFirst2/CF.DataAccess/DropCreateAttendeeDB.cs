using CF.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccess
{
    public class DropCreateAttendeeDB : DropCreateDatabaseIfModelChanges<CodeContext>
    {
        //DropCreateDatabaseIfModelChanges<CodeContext> сработает, только если БД не существует, 
        //т.е. она создает и инициализирует, а если БД существует, то не сработает ни в каких условиях
        protected override void Seed(CodeContext context)
        {
            base.Seed(context);


            context.Attendees.Add(new Attendee { AttendeTracking = 1,  LastName = "Ivanov", 
                                                 FirstName = "Ivan", DateAdded = DateTime.UtcNow });
            context.Attendees.Add(new Attendee { AttendeTracking = 2, LastName = "Petrov", 
                                                 FirstName = "Petr", DateAdded = DateTime.UtcNow });
            context.Attendees.Add(new Attendee { AttendeTracking = 3, LastName = "Andreev", 
                                                 FirstName = "Andrey"  });

            context.SaveChanges();
        }
    }
}

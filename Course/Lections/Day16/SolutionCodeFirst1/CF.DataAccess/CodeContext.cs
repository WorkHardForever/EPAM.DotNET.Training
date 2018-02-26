//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Data.Entity;
namespace ClassLibrary1
{
    public class CodeContext : DbContext
    {
        public CodeContext(string connString = "dbContextCF")
            : base(connString)
        {
        }

        public DbSet<Attendee> Attendees { get; set; }
    }
}



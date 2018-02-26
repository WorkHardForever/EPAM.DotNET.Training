using CF.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccess.Configuration
{
    public class AttendeeSplittedEntityConfig : EntityTypeConfiguration<Attendee>
    {
        public AttendeeSplittedEntityConfig()
        {
            HasKey(p => p.AttendeTracking); ;
            Property(p => p.LastName).IsRequired().HasMaxLength(100);

            Map(e =>
            {
                e.Properties(at => new { at.AttendeTracking, at.DateAdded });
                e.ToTable("AttendeeDates");
            });

            Map(e =>
            {
                e.Properties(at => new { at.AttendeTracking, at.LastName });
                e.ToTable("AttendeeNames");
            });

        }
    }
}
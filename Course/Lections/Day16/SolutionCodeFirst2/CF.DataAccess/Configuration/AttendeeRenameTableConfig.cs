using CF.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccess.Configuration
{
    public class AttendeeRenameTableConfig : EntityTypeConfiguration<Attendee>
    {
        public AttendeeRenameTableConfig()
        {
            HasKey(p => p.AttendeTracking); ;
            Property(p => p.LastName).IsRequired().HasMaxLength(100);
            ToTable("Attendees");
        }
    }
}

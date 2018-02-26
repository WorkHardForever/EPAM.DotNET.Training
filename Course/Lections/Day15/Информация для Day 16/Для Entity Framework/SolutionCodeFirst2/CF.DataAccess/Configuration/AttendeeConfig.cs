using CF.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccess.Configuration
{
    public class AttendeeConfig : EntityTypeConfiguration<Attendee>
    {
        public AttendeeConfig()
        {
            HasKey(p => p.AttendeTracking);
            Property(p => p.LastName).IsRequired().HasMaxLength(70).IsConcurrencyToken(true);
            Property(p => p.DateAdded).IsOptional().HasColumnName("Created").HasColumnType("datetime2");
        }
    }
}

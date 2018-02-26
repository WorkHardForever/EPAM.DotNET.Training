using CF.Data;
using CF.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccess
{
    public class CodeContext : DbContext
    {
        public CodeContext()
            : base("DBContextCF")
        {
        }

        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AttendeeConfig());

            //modelBuilder.Entity<Attendee>().HasKey(it => it.AttendeTracking);

            //modelBuilder.Entity<Attendee>().Property(it => it.LastName)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .IsConcurrencyToken(true);

            //modelBuilder.Entity<Attendee>()
            //    .Property(it => it.DateAdded)
            //    .HasColumnName("Created")
            //    .HasColumnType("datetime2")
            //    .IsOptional();
           
        }
    }
}
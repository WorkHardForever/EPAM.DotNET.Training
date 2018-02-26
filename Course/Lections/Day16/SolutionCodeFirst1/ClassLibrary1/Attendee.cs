using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
    public  class Attendee
    {
        [Key]
        public int AttendeTracking { get; set; }

        [Required, ConcurrencyCheck, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }
                
        [Column("Created", TypeName = "datetime2")]
        public DateTime? DateAdded { get; set; }
    }
}

   
  //public override string ToString()
  //      {
  //          return AttendeTracking + LastName;
  //      }

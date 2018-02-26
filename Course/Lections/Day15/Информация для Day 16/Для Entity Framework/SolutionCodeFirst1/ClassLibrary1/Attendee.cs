using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
    public  class Attendee
    {
        [Key]
        public int AttendeTracking { get; set; }
        //public int AttendeeId { get; set; }

        public string LastName { get; set; }

       
        public string FirstName { get; set; }
                
        
        public DateTime? DateAdded { get; set; }
    }
}

   
  
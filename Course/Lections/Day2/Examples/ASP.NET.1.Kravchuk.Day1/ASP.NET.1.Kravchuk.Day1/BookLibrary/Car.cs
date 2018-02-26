using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
   public  class Car
    {
        public String Name {get; set; }
        // public String Name {get; set; } = "Petr";
        public int Id { get; set; }
        //public int Id { get; set; } = 45;
        public Car() 
        {
            Name = "Petr";
            Id = 45;
        }
        public override string ToString()
        {
            return string.Format("Name: {0} ", Name);
            // return $"Name: {Name} ";
        }
    }
}

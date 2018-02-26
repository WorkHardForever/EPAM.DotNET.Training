using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryGAC
{
    public class Book
    {
        public int ID { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public override string ToString()
        {
            return string.Format("Author: {0} Title: {1}", Author, Title);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//path
//C:\Windows\Microsoft.NET\assembly\GAC_MSIL
//C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools
//C:\Users\MIB\Desktop\ASP.NET.1.Kravchuk.Day1\ASP.NET.1.Kravchuk.Day1\BookLibraryGAC\bin\Debug\BookLibraryGAC.dll

namespace BookLibrary
{
    public class Book: Interface1
    {
        #region Fiels
            private Car car;

            private int id;
        #endregion

#region Property
            public int ID
            {
                get
                {
                    return id;
                }

                set
                { 
                    if (id <= 0)
                        id = 100000;
                    else
                        id = value;
                }
            }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }
#endregion
        public Book(string Author, string Title, Car car)
        {
            this.Author = Author;
            this.Title = Title;
            this.car = car;
        } 

        public override string ToString()
        {
            return string.Format("Author: {0} Title: {1} Car: {2}", Author, Title, car);
           // return $"Author: {Author} Title: {Title} Car: {car}";
        }
       public  /*virtual*/ void F() { }
       
    }
}

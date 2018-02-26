using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeType
{
    public class SomeRefType
    {
          private int m_x; 
          private string m_s;
          private double m_d; 
          private byte m_b;

         public SomeRefType()
         {
             m_x = 5;
             m_s = "Hi there";
             m_d = 3.14159;
             m_b = 0xff; 
         }
         public SomeRefType(int x) : this() 
         {
             m_x = x; 
         }
          public SomeRefType(string s) : this() 
          {
              m_s = s;
          }
          public SomeRefType(int x, string s): this()
          {
              m_x = x;
              m_s = s;
          }


    }


}

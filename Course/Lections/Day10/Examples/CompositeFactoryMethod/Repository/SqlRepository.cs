using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlRepository : AbstractRepository
    {
        public override void Save()
        {
            Console.WriteLine("Save to SQL");
        }
    }
}



using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public class CreatorSqlRepository : IRepositoryFactory
    {
        public virtual AbstractRepository Create()
        {
            return new SqlRepository();
        }
    }
}

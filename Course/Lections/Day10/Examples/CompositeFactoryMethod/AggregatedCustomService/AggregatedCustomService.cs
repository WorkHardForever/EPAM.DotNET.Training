using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatedService
{
    public class AggregatedCustomService
    {
        private readonly AbstractRepository _repository;
        public AggregatedCustomService(AbstractRepository repository)
        { _repository = repository; }

        public void DoSomething()
        {
            // Используем _repository  
            _repository.Save();    
        }
    }
}



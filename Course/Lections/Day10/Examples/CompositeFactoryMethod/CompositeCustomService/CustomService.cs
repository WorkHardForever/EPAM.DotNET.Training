using Repository;
using RepositoryFactory;
using RepositoryFactory.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RepositoryFactory.Creator;

namespace CompositeCustomService
{
    public class CustomService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public void DoSomething()
        {
            var repository = _repositoryFactory.Create();
            // Используем созданный AbstractRepository
            repository.Save();
        }
#region
        //private readonly AbstractRepository _abstractRepository;

        //public CustomService(RepositoryEnum repositoryEnum)
        //{
        //    _abstractRepository = CreatorRepository.Create(repositoryEnum);
        //}
        //public void DoSomething()
        //{
        //    _abstractRepository.Save();
        //}
#endregion
    }
}



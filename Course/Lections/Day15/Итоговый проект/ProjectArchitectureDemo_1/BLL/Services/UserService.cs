using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;
        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }
        //public UserEntity GetUserEntity(int id)
        //{
        //    return userRepository.GetById(id).ToBllUser();
        //}        
        //public IEnumerable<UserEntity> GetAllUserEntities()
        //{
        //    return userRepository.GetAll().Select(user => user.ToBllUser());
        //}
        //public void CreateUser(UserEntity user)
        //{
        //    userRepository.Create(user.ToDalUser());
        //    uow.Commit();
        //}
        //public void DeleteUser(UserEntity user)
        //{
        //    userRepository.Delete(user.ToDalUser());
        //    uow.Commit();
        //}

        #region Public Methods

        public UserEntity GetUserEntity(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        } 
        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }
        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }
        #endregion

        #region Private Methods
        
        #endregion
       
        

    }
}

using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);     
        //etc.
    }
}



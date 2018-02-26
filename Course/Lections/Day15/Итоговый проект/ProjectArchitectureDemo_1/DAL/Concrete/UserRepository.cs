using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            RoleId = user.RoleId
                            
                        });
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return new DalUser()
            {
                Id = ormuser.Id,
                Name = ormuser.Name

            };
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Name = e.Name,
                RoleId = e.RoleId
            };
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            var user = new User()
            {
                Id = e.Id,
                Name = e.Name,
                RoleId = e.RoleId
            };
            user = context.Set<User>().Single(u => u.Id == user.Id);
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
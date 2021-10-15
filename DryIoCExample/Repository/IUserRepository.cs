using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DryIoCExample.Entities;

namespace DryIoCExample.Repository
{
    public interface IUserRepository
    {
        Task Save(User obj);
        Task<IEnumerable<User>> GetAll();    
        Task<User> GetById(Guid id);
    }
}
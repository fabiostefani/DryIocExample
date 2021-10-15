using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DryIoCExample.Entities;

namespace DryIoCExample.Repository
{
    public interface IOrderRepository
    {
        Task Save(Order obj);
        Task<IEnumerable<Order>> GetAll();    
        Task<Order> GetById(Guid id);
    }
}
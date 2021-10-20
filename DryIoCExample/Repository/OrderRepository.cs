using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DryIoCExample.Data;
using DryIoCExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DryIoCExample.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext ctx )
        {
            _context = ctx;
        }

        public async Task Save(Order obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();            
        }
        
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
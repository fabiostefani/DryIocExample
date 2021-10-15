using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryIoCExample.Data;
using DryIoCExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DryIoCExample.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OrderContext _context;
        public UserRepository(OrderContext ctx )
        {
            _context = ctx;
        }

        public async Task Save(User obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();            
        }
        
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
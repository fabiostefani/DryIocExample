using DryIoCExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DryIoCExample.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
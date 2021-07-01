using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Services
{
    public interface IOrderDataAccess
    {
        Task<Order> GetCategory(int id);
        Task<int> AddCategory(Order order);
    }

    public class OrderDataAccess : IOrderDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCategory(Order order)
        {
            order.CreatedAt = DateTime.UtcNow;
            _dbContext.Orders.Add(order);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetCategory(int id)
        {
            Order order = await _dbContext.Orders.FindAsync(id);

            if (order == null || order.DeletedAt != null)
                return null;

            return order;
        }
    }
}

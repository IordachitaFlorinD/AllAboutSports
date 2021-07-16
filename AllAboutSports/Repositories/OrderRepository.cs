using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task<int> AddOrder(Order order);
        Task<int> UpdateOrder(Order updatedorder);
        Task<int> DeleteOrder(int id);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddOrder(Order order)
        {
            order.CreatedAt = DateTime.UtcNow;
            _dbContext.Orders.Add(order);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order order = await _dbContext.Orders.FindAsync(id);

            if (order == null || order.DeletedAt != null)
                return null;

            return order;
        }

        public async Task<int> UpdateOrder(Order updatedorder)
        {
            var order = await _dbContext.Orders.FindAsync(updatedorder.Id);

            if (order == null || order.DeletedAt != null)
                return 0;

            updatedorder.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry(updatedorder).CurrentValues.SetValues(updatedorder);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id)
;
            if (order == null || order.DeletedAt != null)
                return 0;


            order.DeletedAt = DateTime.UtcNow;
            _dbContext.Orders.Update(order);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

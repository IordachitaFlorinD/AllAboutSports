using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Services
{
    public interface IItemDataAccess
    {
        Task<Item> GetCategory(int id);
        Task<int> AddCategory(Item item);
    }

    public class ItemDataAccess : IItemDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCategory(Item item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _dbContext.Items.Add(item);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Item> GetCategory(int id)
        {
            Item item = await _dbContext.Items.FindAsync(id);

            if (item == null || item.DeletedAt != null)
                return null;

            return item;
        }
    }
}

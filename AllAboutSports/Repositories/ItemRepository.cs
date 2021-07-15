using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemById(int id);
        Task<int> AddItem(Item item);
    }

    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Item> GetItemById(int id)
        {
            Item item = await _dbContext.Items.FindAsync(id);

            if (item == null || item.DeletedAt != null)
                return null;

            return item;
        }

        public async Task<int> AddItem(Item item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _dbContext.Items.Add(item);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

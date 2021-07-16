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
        Task<int> UpdateItem(Item updateditem);
        Task<int> DeleteItem(int id);
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

        public async Task<int> UpdateItem(Item updateditem)
        {
            var item = await _dbContext.Items.FindAsync(updateditem.Id);

            if (item == null || item.DeletedAt != null)
                return 0;

            updateditem.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry(updateditem).CurrentValues.SetValues(updateditem);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItem(int id)
        {
            var item = await _dbContext.Items.FindAsync(id)
;
            if (item == null || item.DeletedAt != null)
                return 0;


            item.DeletedAt = DateTime.UtcNow;
            _dbContext.Items.Update(item);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

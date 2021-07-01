using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Services
{
    public interface ICategoryDataAccess
    {
        Task<Category> GetCategory(int id);
        Task<int> AddCategory(Category category);
    }

    public class CategoryDataAccess : ICategoryDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCategory(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;
            _dbContext.Categories.Add(category);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = await _dbContext.Categories.FindAsync(id);

            if (category == null || category.DeletedAt != null)
                return null;

            return category;
        }
    }
}

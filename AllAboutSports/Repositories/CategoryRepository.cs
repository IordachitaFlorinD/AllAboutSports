using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(int id);
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category updatedcategory);
        Task<int> DeleteCategory(int id);

    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            Category category = await _dbContext.Categories.FindAsync(id);

            if (category == null || category.DeletedAt != null)
                return null;

            return category;
        }

        public async Task<int> AddCategory(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;
            _dbContext.Categories.Add(category);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCategory(Category updatedcategory)
        {
            var category = await _dbContext.Categories.FindAsync(updatedcategory.Id);

            if (category == null || category.DeletedAt != null)
                return 0;

            updatedcategory.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry(category).CurrentValues.SetValues(updatedcategory);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id)
;
            if (category == null || category.DeletedAt != null)
                return 0;

            category.DeletedAt = DateTime.UtcNow;
            _dbContext.Categories.Update(category);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

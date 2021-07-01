using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Services
{
    public interface IDeliveryProviderDataAccess
    {
        Task<DeliveryProvider> GetCategory(int id);
        Task<int> AddCategory(DeliveryProvider delivery);
    }

    public class DeliveryProviderDataAccess : IDeliveryProviderDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DeliveryProviderDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCategory(DeliveryProvider delivery)
        {
            delivery.CreatedAt = DateTime.UtcNow;
            _dbContext.DeliveryProviders.Add(delivery);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<DeliveryProvider> GetCategory(int id)
        {
            DeliveryProvider delivery = await _dbContext.DeliveryProviders.FindAsync(id);

            if (delivery == null || delivery.DeletedAt != null)
                return null;

            return delivery;
        }
    }
}

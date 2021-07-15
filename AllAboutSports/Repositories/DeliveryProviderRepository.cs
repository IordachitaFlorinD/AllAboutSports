using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Repositories
{
    public interface IDeliveryProviderRepository
    {
        Task<DeliveryProvider> GetDeliveryProviderById(int id);
        Task<int> AddDeliveryProvider(DeliveryProvider deliveryProvider);
    }

    public class DeliveryProviderRepository : IDeliveryProviderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeliveryProviderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DeliveryProvider> GetDeliveryProviderById(int id)
        {
            DeliveryProvider deliveryProvider = await _dbContext.DeliveryProviders.FindAsync(id);

            if (deliveryProvider == null || deliveryProvider.DeletedAt != null)
                return null;

            return deliveryProvider;
        }

        public async Task<int> AddDeliveryProvider(DeliveryProvider deliveryProvider)
        {
            deliveryProvider.CreatedAt = DateTime.UtcNow;
            _dbContext.DeliveryProviders.Add(deliveryProvider);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

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
        Task<int> UpdateDeliveryProvider(DeliveryProvider updateddeliveryProvider);
        Task<int> DeleteDeliveryProvider(int id);

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

        public async Task<int> UpdateDeliveryProvider(DeliveryProvider updateddeliveryProvider)
        {
            var deliveryProvider = await _dbContext.DeliveryProviders.FindAsync(updateddeliveryProvider.Id);

            if (deliveryProvider == null || deliveryProvider.DeletedAt != null)
                return 0;

            updateddeliveryProvider.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry(deliveryProvider).CurrentValues.SetValues(updateddeliveryProvider);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteDeliveryProvider(int id)
        {
            var deliveryProvider = await _dbContext.DeliveryProviders.FindAsync(id)
;
            if (deliveryProvider == null || deliveryProvider.DeletedAt != null)
                return 0;


            deliveryProvider.DeletedAt = DateTime.UtcNow;
            _dbContext.DeliveryProviders.Update(deliveryProvider);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

using AllAboutSports.Data;
using AllAboutSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Repositories
{
    public interface IShippingAddressRepository
    {
        Task<ShippingAddress> GetShippingAddressById(int id);
        Task<int> AddShippingAddress(ShippingAddress shippingAddress);
        Task<int> UpdateShippingAddress(ShippingAddress updateshippingAddress);
        Task<int> DeleteShippingAddress(int id);
    }

    public class ShippingAddressRepository : IShippingAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShippingAddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ShippingAddress> GetShippingAddressById(int id)
        {
            ShippingAddress shippingAddress = await _dbContext.ShippingAddresses.FindAsync(id);

            if (shippingAddress == null || shippingAddress.DeletedAt != null)
                return null;

            return shippingAddress;
        }

        public async Task<int> AddShippingAddress(ShippingAddress shippingAddress)
        {
            shippingAddress.CreatedAt = DateTime.UtcNow;
            _dbContext.ShippingAddresses.Add(shippingAddress);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateShippingAddress(ShippingAddress updateshippingAddress)
        {
            var shippingAddress = await _dbContext.ShippingAddresses.FindAsync(updateshippingAddress.Id);

            if (shippingAddress == null || shippingAddress.DeletedAt != null)
                return 0;

            updateshippingAddress.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry(updateshippingAddress).CurrentValues.SetValues(updateshippingAddress);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteShippingAddress(int id)
        {
            var shippingAddress = await _dbContext.ShippingAddresses.FindAsync(id)
;
            if (shippingAddress == null || shippingAddress.DeletedAt != null)
                return 0;


            shippingAddress.DeletedAt = DateTime.UtcNow;
            _dbContext.ShippingAddresses.Update(shippingAddress);

            return await _dbContext.SaveChangesAsync();
        }
    }
}

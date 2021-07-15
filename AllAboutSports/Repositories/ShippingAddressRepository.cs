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
    }
}

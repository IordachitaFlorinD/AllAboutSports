using AllAboutSports.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ItemCart> ItemsCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryProvider> DeliveryProviders { get; set; }
        public DbSet<ItemFeedback> ItemsFeedbacks { get; set; }
        public DbSet<ItemOrder> ItemsOrders { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<ItemCart>().ToTable("ItemCart");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<DeliveryProvider>().ToTable("DeliveryProvider");
            modelBuilder.Entity<ItemFeedback>().ToTable("ItemFeedback");
            modelBuilder.Entity<ItemOrder>().ToTable("ItemOrder");
            modelBuilder.Entity<ShippingAddress>().ToTable("ShippingAddress");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShippingAddressId { get; set; }
        public int DeliveryProviderId{ get; set; }
        public int State { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

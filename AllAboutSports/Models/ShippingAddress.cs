using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}

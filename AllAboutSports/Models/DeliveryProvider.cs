using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Models
{
    public class DeliveryProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string Currency { get; set; }
        public string EstimateTime { get; set; }
        public int MinimumPrice { get; set; }
        public bool Available { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

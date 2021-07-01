using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Models
{
    public class ItemCart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}

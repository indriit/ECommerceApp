using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class Wishlist
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}

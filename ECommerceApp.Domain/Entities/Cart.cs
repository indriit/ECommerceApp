using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class Cart
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}

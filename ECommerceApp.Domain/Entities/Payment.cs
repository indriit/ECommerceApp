using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class Payment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Methode { get; set; }
        public decimal Amount { get; set; }
    }
}

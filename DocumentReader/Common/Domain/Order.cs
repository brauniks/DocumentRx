using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Model
{
   public class Order
    {
        public int? Id { get; set; }
        public int Quantity { get; set; }
        public Customer CustomerId { get; set; }
        public Product ProductId { get; set; }

        public static implicit operator Dictionary<object, object>(Order v)
        {
            throw new NotImplementedException();
        }
    }
}

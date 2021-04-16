using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }   
        public double Total
        {
            get
            {
                return CartLines.Sum(c => c.Product.Price * c.Quantity);
            }
        }
        public List<CartLine> CartLines { get; set; }
    }
}

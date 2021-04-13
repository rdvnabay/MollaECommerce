using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WishList
    {
        public WishList()
        {
            WishListLines = new List<WishListLine>();
        }

        public List<WishListLine> WishListLines { get; set; } 
    }
}

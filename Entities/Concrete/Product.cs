using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public Product()
        {
            Images = new List<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Features { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Image>Images { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}

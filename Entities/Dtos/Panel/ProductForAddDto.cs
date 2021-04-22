using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.Panel
{
    public class ProductForAddDto:IDto
    {
        public int Id { get; set; }

        //Product
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public short Stock { get; set; }
        public decimal Price { get; set; }

        //ProductDetail
        public bool IsActive { get; set; }
        public bool IsTopSelling { get; set; }
        public bool IsNewProduct { get; set; }
        public bool IsHome { get; set; }

        //Category
        public int CategoryId { get; set; }


        //Images
        public List<Image> Images { get; set; }
    }
}

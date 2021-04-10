﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Image:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

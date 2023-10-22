﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entites
{

    public class Product : EntityBase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public string? PictureUrl { get; set; }

        public int CategoryId { get; set; }

        public ProductCategory? Category { get; set; }

        public int BrandId { get; set; }

        public ProductBrand? Brand { get; set; }

    }

}

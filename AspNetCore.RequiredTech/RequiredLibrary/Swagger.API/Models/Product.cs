﻿using System;
using System.Collections.Generic;

namespace Swagger.API.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
        public string? Category { get; set; }
    }
}

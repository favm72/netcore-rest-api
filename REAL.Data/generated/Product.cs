using System;
using System.Collections.Generic;

namespace REAL.Data.generated
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Provider { get; set; }
        public int? Discount { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

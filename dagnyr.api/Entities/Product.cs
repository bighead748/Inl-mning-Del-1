using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dagnyr.api.Entities;

    public class Product
    {
        public int ProductId { get; set; }
        public string ItemNumber { get; set; } ="";
        public string ProductName { get; set; } ="";
        public double Price { get; set; }

        public IList<Supplier> Suppliers { get; set; }

    }

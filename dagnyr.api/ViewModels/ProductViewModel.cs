using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dagnyr.api.ViewModels;

    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } ="";
        public double Price { get; set; }
    }

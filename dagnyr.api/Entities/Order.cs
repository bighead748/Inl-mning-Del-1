using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dagnyr.api.Entities;

    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }

        public IList<Supplier> Suppliers { get; set; }
    }

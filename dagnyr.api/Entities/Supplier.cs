using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dagnyr.api.Entities;

    public class Supplier
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public double PricePerKg { get; set; }
        public string SupplierName { get; set; } ="";
        public string SupplierAddress { get; set; } ="";
        public string ContactPerson { get; set; } ="";
        public string PhoneNumber { get; set; } ="";
        public string Email { get; set; } ="";

        public Product Product { get; set; }
        public Order Order { get; set; }

    }

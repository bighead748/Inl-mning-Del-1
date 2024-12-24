using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dagnyr.api.Entities;

namespace dagnyr.api.ViewModels;

    public class OrderViewModel
    {
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }

        public IList<ProductViewModel> Products { get; set; }
    }

using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Products
    {
        public Products()
        {
            SpareParts = new HashSet<SpareParts>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; }

        public ICollection<SpareParts> SpareParts { get; set; }
    }
}

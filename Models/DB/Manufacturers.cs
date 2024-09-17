using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            SpareParts = new HashSet<SpareParts>();
        }

        public int IdManufacturer { get; set; }
        public string Name { get; set; }

        public ICollection<SpareParts> SpareParts { get; set; }
    }
}

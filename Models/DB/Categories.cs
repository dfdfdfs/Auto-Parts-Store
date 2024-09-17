using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Categories
    {
        public Categories()
        {
            SpareParts = new HashSet<SpareParts>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }

        public ICollection<SpareParts> SpareParts { get; set; }
    }
}

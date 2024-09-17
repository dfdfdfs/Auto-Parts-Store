using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Models
    {
        public Models()
        {
            SpareParts = new HashSet<SpareParts>();
        }

        public int IdModel { get; set; }
        public string Name { get; set; }
        public int FkIdBrand { get; set; }

        public Brands FkIdBrandNavigation { get; set; }
        public ICollection<SpareParts> SpareParts { get; set; }
    }
}

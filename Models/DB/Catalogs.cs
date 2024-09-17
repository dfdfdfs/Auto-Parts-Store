using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Catalogs
    {
        public int IdCatalog { get; set; }
        public int FkIdSparePart { get; set; }
        public decimal Price { get; set; }

        public SpareParts FkIdSparePartNavigation { get; set; }
    }
}

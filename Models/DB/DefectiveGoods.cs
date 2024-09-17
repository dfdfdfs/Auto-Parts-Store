using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class DefectiveGoods
    {
        public int IdDefect { get; set; }
        public int FkIdSupplies { get; set; }
        public int Amount { get; set; }

        public Supplies FkIdSuppliesNavigation { get; set; }
    }
}

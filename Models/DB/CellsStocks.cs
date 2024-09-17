using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class CellsStocks
    {
        public CellsStocks()
        {
            SparePartStock = new HashSet<SparePartStock>();
        }

        public int IdCell { get; set; }
        public int Number { get; set; }
        public int FkIdStock { get; set; }
        public int Capacity { get; set; }

        public Stock FkIdStockNavigation { get; set; }
        public ICollection<SparePartStock> SparePartStock { get; set; }
    }
}

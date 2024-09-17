using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Applications
    {
        public int IdApplication { get; set; }
        public int FkIdClient { get; set; }
        public int FkIdSparePart { get; set; }

        public Clients FkIdClientNavigation { get; set; }
        public SpareParts FkIdSparePartNavigation { get; set; }
    }
}

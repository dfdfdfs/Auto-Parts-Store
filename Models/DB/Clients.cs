using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Clients
    {
        public Clients()
        {
            Applications = new HashSet<Applications>();
            Sales = new HashSet<Sales>();
        }

        public int IdClient { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }

        public ICollection<Applications> Applications { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}

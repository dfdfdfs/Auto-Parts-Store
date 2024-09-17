using System;
using System.Collections.Generic;

namespace AutoPartsStore.Models.DB
{
    public partial class Brands
    {
        public Brands()
        {
            Models = new HashSet<Models>();
        }

        public int IdBrand { get; set; }
        public string Name { get; set; }

        public ICollection<Models> Models { get; set; }
    }
}

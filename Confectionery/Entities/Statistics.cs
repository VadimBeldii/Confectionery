using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.DAL.EF.Entities
{
    public class Statistics
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Purchased { get; set; }
        public int PurchasedSeparately { get; set; }
    }
}

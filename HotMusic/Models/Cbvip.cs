using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class Cbvip
    {
        public Cbvip()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public double? PriceDiscount { get; set; }
        public DateTime? Time { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}

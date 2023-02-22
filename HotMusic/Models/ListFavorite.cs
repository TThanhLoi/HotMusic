using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class ListFavorite
    {
        public ListFavorite()
        {
            ListFavoriteDetails = new HashSet<ListFavoriteDetail>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string Name { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ListFavoriteDetail> ListFavoriteDetails { get; set; }
    }
}

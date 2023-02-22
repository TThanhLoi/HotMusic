using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class ListFavoriteDetail
    {
        public int Id { get; set; }
        public int? ListFavoriteId { get; set; }
        public int? MusicId { get; set; }
        public string MusicName { get; set; }

        public virtual ListFavorite ListFavorite { get; set; }
        public virtual Music Music { get; set; }
    }
}

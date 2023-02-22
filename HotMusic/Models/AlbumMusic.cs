using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class AlbumMusic
    {
        public int Id { get; set; }
        public int? MusicId { get; set; }
        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Music Music { get; set; }
    }
}

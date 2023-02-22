using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class MusicMp3
    {
        public int Id { get; set; }
        public int? SingerId { get; set; }
        public int? MusicId { get; set; }

        public virtual Music Music { get; set; }
        public virtual Singer Singer { get; set; }
    }
}

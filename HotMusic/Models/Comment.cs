using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? MusicId { get; set; }
        public int? AccountId { get; set; }
        public string Comment1 { get; set; }

        public virtual Account Account { get; set; }
        public virtual Music Music { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class Singer
    {
        public Singer()
        {
            MusicMp3s = new HashSet<MusicMp3>();
        }

        public int Id { get; set; }
        public string SingerName { get; set; }
        public string Image { get; set; }

        public virtual ICollection<MusicMp3> MusicMp3s { get; set; }
    }
}

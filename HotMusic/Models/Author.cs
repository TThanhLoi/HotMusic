using System;
using System.Collections.Generic;

#nullable disable

namespace HotMusic.Models
{
    public partial class Author
    {
        public Author()
        {
            Musics = new HashSet<Music>();
        }

        public int Id { get; set; }
        public string AuthorName { get; set; }

        public virtual ICollection<Music> Musics { get; set; }
    }
}

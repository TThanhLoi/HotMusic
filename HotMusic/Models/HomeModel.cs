using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace HotMusic.Models
{
    public class HomeModel
    {
        public List<Music> ListMusic { get; set; }
        public List<Singer> ListSinger { get; set; }
        public List<MusicMp3> ListMusicMp3 { get; set; }
        public List<AlbumMusic> ListAlbumMusic { get; set; }
        public List<Album> ListAlbum { get; set; }
    }
}

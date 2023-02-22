using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotMusic.Models
{
    public partial class Music
    {
        public Music()
        {
            AlbumMusics = new HashSet<AlbumMusic>();
            Comments = new HashSet<Comment>();
            ListFavoriteDetails = new HashSet<ListFavoriteDetail>();
            MusicMp3s = new HashSet<MusicMp3>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên bài hát")]
        [MinLength(6,ErrorMessage = "ít nhất 6 ký tự nha!!!")]
        public string MusiceName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn Author")]
        public int? AuthorId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập url")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lượt nghe")]
        public int? ListenQuantity { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lượt download")]
        public int? DownloadQuantity { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lượt thích")]
        public int? FavoriteQuantity { get; set; }
        public bool IsVip { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<AlbumMusic> AlbumMusics { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ListFavoriteDetail> ListFavoriteDetails { get; set; }
        public virtual ICollection<MusicMp3> MusicMp3s { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotMusic.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumMusics = new HashSet<AlbumMusic>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên Album")]
        [MinLength(6, ErrorMessage = "ít nhất 6 ký tự nha!!!")]
        public string Name { get; set; }
        public string Imange { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập url")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày tạo")]
        public DateTime? Createdate { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lượt thích")]
        public int? FavoriteQuantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AlbumMusic> AlbumMusics { get; set; }
    }
}

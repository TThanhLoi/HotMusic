using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotMusic.Models
{
    public partial class Category
    {
        public Category()
        {
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên thể loại")]
        [MinLength(6, ErrorMessage = "ít nhất 6 ký tự nha!!!")]
        public string CategoryName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}

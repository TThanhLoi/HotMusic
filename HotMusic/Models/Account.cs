using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotMusic.Models
{
    public partial class Account
    {
        public Account()
        {
            Comments = new HashSet<Comment>();
            ListFavorites = new HashSet<ListFavorite>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Username")]
        [MinLength(6, ErrorMessage = "ít nhất 6 ký tự nha!!!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập password")]
        [MinLength(6, ErrorMessage = "ít nhất 6 ký tự nha!!!")]
        public string Password { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Fullname")]
        [MinLength(6, ErrorMessage = "ít nhất 6 ký tự nha!!!")]
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại")]
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int? IdVip { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Cbvip IdVipNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ListFavorite> ListFavorites { get; set; }
    }
}

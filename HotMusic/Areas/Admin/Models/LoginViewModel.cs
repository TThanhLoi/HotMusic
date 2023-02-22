using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotMusic.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [Display(Name = "Điện Thoại / Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [MinLength(5, ErrorMessage = "Bạn cần đặt tối thiểu 5 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
    }
}

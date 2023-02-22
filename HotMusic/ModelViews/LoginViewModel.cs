using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotMusic.ModelViews
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        [Display(Name="Điện Thoại / Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [MinLength(5,ErrorMessage ="Bạn cần đặt tối thiểu 5 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

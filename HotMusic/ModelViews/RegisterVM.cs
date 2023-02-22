using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotMusic.ModelViews
{
    public class RegisterVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Họ Và Tên")]
        [Required(ErrorMessage ="Vui lòng nhập Họ Tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "ValidateEmail", controller:"Account")]
        public  string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại")]
        [MaxLength(11)]
        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "ValidatePhone", controller: "Account")]
        public string Phone { get; set; }
        [MinLength(5,ErrorMessage ="Bạn cần đặt tối thiểu 5 ký tự")]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng mật khẩu")]
        public  string Password { get; set; }
        [MinLength(5, ErrorMessage = "Bạn cần đặt tối thiểu 5 ký tự")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password",ErrorMessage ="Vui lòng nhập mật khẩu giống nhau")]
        public string ConfirmPassword { get; set; }
    }
}

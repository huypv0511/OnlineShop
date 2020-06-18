using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        [EmailAddress(ErrorMessage = "Không đúng định dạng Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "Mật khẩu tối đa {0} và tối thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "Mật khẩu và xác thực mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Họ và tên")]
        public string Name { get; set; }


        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại.")]
        [StringLength(12, ErrorMessage = "Số điện thoại tối đa {1} và tối thiểu {2} ký tự.", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
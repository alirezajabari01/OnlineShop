using OnlineShop.Core.CustomizeAttributes.ErrorMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "فعالیت")]
        public bool IsActive { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(PasswordErrorMessageHandler.PasswordMaxLenght
                   , ErrorMessage = PasswordErrorMessageHandler.PasswordMaxLenghtErrorMessage)]
        [MinLength(PasswordErrorMessageHandler.PasswordMinLenght
                   , ErrorMessage = PasswordErrorMessageHandler.PasswordMinLenghtErrorMessage)]
       // [RegularExpression(PasswordErrorMessageHandler.RequiredCharacters)]
        public string PasswordHash { get; set; }
    }
}

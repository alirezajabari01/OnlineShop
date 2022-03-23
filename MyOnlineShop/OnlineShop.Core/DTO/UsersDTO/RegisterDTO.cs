using OnlineShop.Core.CustomizeAttributes.ErrorMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.UsersDTO
{
    public class RegisterDTO
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(PasswordErrorMessageHandler.PasswordMaxLenght
                          , ErrorMessage = PasswordErrorMessageHandler.PasswordMaxLenghtErrorMessage)]

        [MinLength(PasswordErrorMessageHandler.PasswordMinLenght
                          , ErrorMessage = PasswordErrorMessageHandler.PasswordMinLenghtErrorMessage)]
        //[RegularExpression(PasswordErrorMessageHandler.RequiredCharacters)]
        [DataType(DataType.Password)]

        public string PasswordHash { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare("PasswordHash", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        [MaxLength(PasswordErrorMessageHandler.PasswordMaxLenght
                         , ErrorMessage = PasswordErrorMessageHandler.PasswordMaxLenghtErrorMessage)]

        [MinLength(PasswordErrorMessageHandler.PasswordMinLenght
                         , ErrorMessage = PasswordErrorMessageHandler.PasswordMinLenghtErrorMessage)]
        //[RegularExpression(PasswordErrorMessageHandler.RequiredCharacters)]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.CustomizeAttributes.ErrorMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.UsersDTO
{
    public class LoginDTO
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Remote(action: "CheckUserNameAsync",controller:"Accounts",HttpMethod ="POST")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(PasswordErrorMessageHandler.PasswordMaxLenght
                  , ErrorMessage = PasswordErrorMessageHandler.PasswordMaxLenghtErrorMessage)]
        [MinLength(PasswordErrorMessageHandler.PasswordMinLenght
                  , ErrorMessage = PasswordErrorMessageHandler.PasswordMinLenghtErrorMessage)]
        //[RegularExpression(PasswordErrorMessageHandler.RequiredCharacters)]
        public string PasswordHash { get; set; }

    }
}

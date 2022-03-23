using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.CustomizeAttributes.ErrorMessages
{
    public class PasswordErrorMessageHandler
    {
        public const int PasswordMaxLenght = 20;
        public const string PasswordMaxLenghtErrorMessage = "حداکثر مجاز پسورد 20 کاراکتر میباشد";

        public const int PasswordMinLenght = 8;
        public const string PasswordMinLenghtErrorMessage = "حداقل مجاز پسورد 8 کاراکتر میباشد";
               
        public const string PasswordRequiredErrorMessage = "وارد کردن کلمه عبور اجباری است";
               
        public const string RequiredCharacters = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]).{8,20}$";
    }
}

using App.Model;
using System.Text.RegularExpressions;

namespace App.Utils.Validators
{
    class UserValidator
    {
        User User;
        string ConfirmPass;

        public UserValidator()
        {

        }

        public UserValidator(User userInput, string confirmPass)
        {
            User = userInput;
            ConfirmPass = confirmPass;
        }

        public string ValidateUser()
        {
            string errMsg = "";
            errMsg += User.username.Length == 0 ? "Username must not be empty! \n" : "";
            errMsg += User.password.Length == 0 ? "Password must not be empty! \n" : "";
            errMsg += User.firstname.Length == 0 ? "First name must not be empty! \n" : "";
            errMsg += User.lastname.Length == 0 ? "Last name must not be empty! \n" : "";
            errMsg += ConfirmPass.Length == 0 ? "Confirm password must not be empty! \n" : "";
            if(errMsg.Length == 0)
            {
                if(User.password != ConfirmPass)
                {
                    errMsg += "Passwords don't match! \n";
                }
                else
                {
                    var usernameRegex = @"^(?=.{5,}$).*$";
                    var passRegex = @"^(?=.{10,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W).*$";
                    if(!Regex.Match(User.username, usernameRegex, RegexOptions.IgnoreCase).Success)
                    {
                        errMsg += "Invalid username! \n -at least 5 characters \n -one symbol(@#$%^&-_) \n";
                    }
                    if(!Regex.Match(User.password, passRegex, RegexOptions.IgnoreCase).Success)
                    {
                        errMsg += "Invalid passwords! \n -at least 10 characters \n -one uppercase letter \n -one digit \n -one symbol(@#%^&+=) \n";
                    }
                }
                return errMsg;
            }
            else
            {
                return errMsg;
            }
        }

    }
}

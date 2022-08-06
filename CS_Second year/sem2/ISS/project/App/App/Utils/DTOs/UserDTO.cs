using App.Model;
using static App.Utils.Enums.Enums;

namespace App.Utils.DTOs
{
    class UserDTO
    {
        private User User;
        private string ConfirmPass;
        public User user
        {
            get { return User; }
            set { User = value; }
        }

        public string confirmpass
        {
            get { return ConfirmPass; }
            set { ConfirmPass = value; }
        }

        public UserDTO(User user, string confirm_pass)
        {
            User = user;
            ConfirmPass = confirm_pass;
        }

        public UserDTO()
        {
        }

        public override string ToString()
        {
            return " User = " + User.ToString() + "\n" +
                   " Confirm pass =  " + ConfirmPass;
        }
    }
}

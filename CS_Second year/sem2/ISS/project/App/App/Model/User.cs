using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Utils.Enums.Enums;

namespace App.Model
{ 
    class User
    {
        private string Username;

        private string Password;

        private string FirstName;

        private string LastName;

        private EmployeeType Type;

        public string username
        {
            get { return Username; }
            set { Username = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string firstname
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public string lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public EmployeeType type {
            get { return Type; }
            set { Type = value; }
        }

        public User(string username, string password, string firstName, string lastName, EmployeeType type)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return " Username = " + Username + 
                " Password =  " + Password + 
                " Firstname =  " + FirstName + 
                " Lastname = " + LastName + 
                " Type =  " + Type;
        }

    }
}

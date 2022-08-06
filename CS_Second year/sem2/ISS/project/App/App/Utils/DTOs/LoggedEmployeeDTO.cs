using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Utils.Enums.Enums;

namespace App.Utils.DTOs
{
    class LoggedEmployeeDTO
    {
        private string Username;

        private EmployeeType Type;

        public string username
        {
            get { return Username; }
            set { Username = value; }
        }

        public EmployeeType type
        {
            get { return Type; }
            set { Type = value; }
        }

        public LoggedEmployeeDTO(string username, EmployeeType type)
        {
            Username = username;
            Type = type;
        }

        public LoggedEmployeeDTO()
        {
        }

        public override string ToString()
        {
            return " Username = " + Username +
                " Types =  " + Type;
        }
    }
}

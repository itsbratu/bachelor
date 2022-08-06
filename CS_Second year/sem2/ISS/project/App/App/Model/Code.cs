using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Utils.Enums.Enums;

namespace App.Model
{
    class Code
    {
        private int ID { get; set; }
        private string Description { get; set; }
        private Functionality Functionality { get; set; }
        private DateTime AddedDate { get; set; }
        private User User { get; set; }

        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }

        public Functionality functionality
        {
            get { return Functionality; }
            set { Functionality = value; }
        }

        public DateTime addeddate
        {
            get { return AddedDate; }
            set { AddedDate = value; }
        }

        public User user
        {
            get { return User; }
            set { User = value; }
        }

        public Code()
        {

        }
        public Code(int iD, string description, Functionality functionality, DateTime addedDate, User user)
        {
            ID = iD;
            Description = description;
            Functionality = functionality;
            AddedDate = addedDate;
            User = user;
        }

        public override string ToString()
        {
            return 
                "Description: " + Description + Environment.NewLine +
                "Functionality: " + Functionality + Environment.NewLine +
                "AddedDate: " + AddedDate + Environment.NewLine;
        }
    }
}

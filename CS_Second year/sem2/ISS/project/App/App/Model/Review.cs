using static App.Utils.Enums.Enums;

namespace App.Model
{
    class Review
    {
        private int ID;
        private string Description;
        private CodeQuality Quality;
        private User Programmer;
        private Code Code;

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

        public CodeQuality quality
        {
            get { return Quality; }
            set { Quality = value; }
        }

        public User programmer
        {
            get { return Programmer; }
            set { Programmer = value; }
        }

        public Code code
        {
            get { return Code; }
            set { Code = value; }
        }
        public Review(int iD, string description, CodeQuality quality, User programmer, Code code)
        {
            ID = iD;
            Description = description;
            Quality = quality;
            Programmer = programmer;
            Code = code;
        }

        public Review()
        {

        }
        public override string ToString()
        {
            return " ID = " + ID + "\n" +
                " Description = " + Description + "\n" +
                " Quality = " + Quality + "\n" +
                " Programmer =  " + Programmer.ToString() + "\n" +
                " ReviewedCode = " + Code.ToString();
        }

    }
}

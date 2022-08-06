using static App.Utils.Enums.Enums;

namespace App.Model
{
    class Bug
    {
        private int ID;
        private string Description;
        private SeverityStatus Severity;
        private User Tester;
        private Code Code;

        public int id {
            get { return ID; }
            set { ID = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }

        public SeverityStatus severity
        {
            get { return Severity; }
            set { Severity = value; }
        }

        public User tester
        {
            get { return Tester; }
            set { Tester = value; }
        }

        public Code code
        {
            get { return Code; }
            set { Code = value; }
        }

        public Bug()
        {

        }
        public Bug(int iD, string description, SeverityStatus severity, User tester, Code code)
        {
            ID = iD;
            Description = description;
            Severity = severity;
            Tester = tester;
            Code = code;
        }

        public override string ToString()
        {
            return " ID = " + ID + "\n" +
                " Description = " + Description + "\n" +
                " Severity = " + Severity + "\n" +
                " Tester =  " + Tester.ToString() + "\n" +
                " Code = " + Code.ToString() + "\n";
        }

    }
}

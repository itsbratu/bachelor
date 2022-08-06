using static App.Utils.Enums.Enums;

namespace App.Utils.DTOs
{
    class BugViewDTO
    {
        private int Id_bug;
        private int Id_code;
        private string Username_tester;
        private SeverityStatus Severity;

        public int id_bug
        {
            get { return Id_bug; }
            set { Id_bug = value; }
        }
        public int id_code
        {
            get { return Id_code; }
            set { Id_code = value; }
        }

        public string username_tester
        {
            get { return Username_tester; }
            set { Username_tester = value; }
        }

        public SeverityStatus severity
        {
            get { return Severity; }
            set { Severity = value; }
        }

        public BugViewDTO()
        {

        }

        public BugViewDTO(int id_bug, int id_code, string username_tester, SeverityStatus severity)
        {
            Id_bug = id_bug;
            Id_code = id_code;
            Username_tester = username_tester;
            Severity = severity;
        }

    }
}

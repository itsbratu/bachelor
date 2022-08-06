using static App.Utils.Enums.Enums;

namespace App.Utils.DTOs
{
    class ReviewViewDTO
    {
        private int Id_review;
        private int Id_code;
        private string Username_reviewer;
        private CodeQuality Quality;

        public int id_review
        {
            get { return Id_review; }
            set { Id_review = value; }
        }
        public int id_code
        {
            get { return Id_code; }
            set { Id_code = value; }
        }

        public string username_reviewer
        {
            get { return Username_reviewer; }
            set { Username_reviewer = value; }
        }

        public CodeQuality quality
        {
            get { return Quality; }
            set { Quality = value; }
        }

        public ReviewViewDTO()
        {

        }

        public ReviewViewDTO(int id_review, int id_code, string username_reviewer, CodeQuality quality)
        {
            Id_review = id_review;
            Id_code = id_code;
            Username_reviewer = username_reviewer;
            Quality = quality;
        }
    }
}

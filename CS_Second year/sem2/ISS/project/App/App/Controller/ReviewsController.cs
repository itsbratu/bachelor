using App.Model;
using App.Repository;
using System.Collections.Generic;
using System.Linq;
using static App.Utils.Enums.Enums;

namespace App.Controller
{
    class ReviewsController
    {
        ReviewRepository reviewRepo;
        CodeRepository codeRepository;
        UsersRepository usersRepository;

        public ReviewsController()
        {
            reviewRepo = new ReviewRepository();
            codeRepository = new CodeRepository();
            usersRepository = new UsersRepository();
        }

        public IList<int> GetCodeIds()
        {
            IList<int> CodeIDs = new List<int>();
            foreach (Code c in codeRepository.GetAll())
            {
                CodeIDs.Add(c.id);
            }
            return CodeIDs;
        }

        public void AddReview(int id_code, string username_reviewer, string description, CodeQuality quality)
        {
            User reviewer = usersRepository.FindByID(username_reviewer);
            foreach (Code c in codeRepository.GetAll())
            {
                if (c.id == id_code)
                {
                    Code reviewCode = new Code(c.id, c.description, c.functionality, c.addeddate, c.user);
                    Review review = new Review(0, description, quality, reviewer, reviewCode);
                    reviewRepo.Add(review);
                    break;
                }
            }
        }

        public IList<Review> GetReviews(string LoggedUsername)
        {
            return reviewRepo.GetAll().Where(e => e.code.user.username == LoggedUsername).ToList();
        }

    }
}

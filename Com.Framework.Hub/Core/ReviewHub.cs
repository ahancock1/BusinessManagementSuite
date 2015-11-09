using System.Collections.Generic;
using System.Linq;
using Com.Framework.Data;

namespace Com.Framework.Hubs.Core
{
    public interface IReviewHub
    {
        Review GetReview(int id);

        IEnumerable<Review> GetReviewsByPremise(int premiseID, int start = 0, int count = 0);

        IEnumerable<Review> GetReviewsByUser(int userID);
    }

    public interface IReviewContract
    {
        void UpdateReviews(params Review[] reviews);
    }

    public class ReviewHub : ServiceHub<IReviewContract>, IReviewHub
    {
        public Review GetReview(int id)
        {
            return Service.Get<Review>(r => r.Id == id);
        }

        public IEnumerable<Review> GetReviewsByPremise(int premiseID, int start = 0, int count = 0)
        {
            return Service.All<Review>(r => r.PremiseID == premiseID).Skip(start).Take(count);
        }

        public IEnumerable<Review> GetReviewsByUser(int userID)
        {
            return Service.All<Review>(r => r.UserID == userID);
        }
    }
}

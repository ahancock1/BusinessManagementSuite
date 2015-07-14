using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Restaurant.Data;
using Restaurant.Data.Accounting;
using Restaurant.DataAccess.Services;

namespace Restaurant.Service
{
    public interface IReviewService
    {
        bool Update(Review[] reviews);


    }

    public class ReviewService : IReviewService
    {
        private readonly IGenericService service = new GenericService();

        /// <summary>
        /// Adds reviews and updates the venue ratings and review count accordingly
        /// </summary>
        /// <param name="reviews"></param>
        /// <returns></returns>
        public bool Update(Review[] reviews)
        {
            service.Update<Review>(reviews);

            foreach (Review review in reviews)
            {
                Venue result = service.Get<Venue>(v => v.VenueID == review.Venue.VenueID);
                result.EntityState = EntityState.Modified;

                result.UserRating = service.All<Review>(r => r.Venue.VenueID == review.Venue.VenueID, r => r.Venue).Sum(r => r.Rating) / (result.UserReviews + (int)review.EntityState);
                result.UserReviews += (int)review.EntityState;

                service.Update<Venue>(result);
            }

            return true;
        }
    }
}

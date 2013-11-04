using CI.Entities;

namespace CI.DAL
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(CIContext context) : base(context) { }
    }
}
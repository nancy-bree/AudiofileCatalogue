using System.Linq;
using CI.Entities;

namespace CI.DAL
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(CIContext context) : base(context) { }

        public bool HasVoted(int userId, int audiofileId)
        {
            var query = _context.Ratings.FirstOrDefault(x => x.UserID == userId && x.AudiofileID == audiofileId);
            return query != null;
        }
    }
}
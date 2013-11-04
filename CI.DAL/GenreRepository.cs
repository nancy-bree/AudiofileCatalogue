using CI.Entities;

namespace CI.DAL
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(CIContext context) : base(context) { }
    }
}
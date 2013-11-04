using CI.Entities;

namespace CI.DAL
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(CIContext context) : base(context) { }
    }
}
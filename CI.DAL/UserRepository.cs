using CI.Entities;

namespace CI.DAL
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(CIContext context) : base(context) { }
    }
}
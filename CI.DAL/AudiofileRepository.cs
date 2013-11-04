using CI.Entities;

namespace CI.DAL
{
    public class AudiofileRepository : Repository<Audiofile>
    {
        public AudiofileRepository(CIContext context) : base(context) { }
    }
}
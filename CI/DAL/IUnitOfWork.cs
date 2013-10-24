using System;
using CI.DAL;

namespace CI.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        AuthorRepository AuthorRepository { get; }
        GenreRepository GenreRepository { get; }
        AudiofileRepository AudiofileRepository { get; }
        RatingRepository RatingRepository { get; }
        UserRepository UserRepository { get; }
        void Save();
    }
}

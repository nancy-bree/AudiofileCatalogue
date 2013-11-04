using System;

namespace CI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CIContext _context = new CIContext();
        private AuthorRepository _authorRepository;
        private GenreRepository _genreRepository;
        private AudiofileRepository _audiofileRepository;
        private RatingRepository _ratingRepository;
        private UserRepository _userRepository;

        public AuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_context);
                }
                return _authorRepository;
            }
        }

        public GenreRepository GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                {
                    _genreRepository = new GenreRepository(_context);
                }
                return _genreRepository;
            }
        }

        public AudiofileRepository AudiofileRepository
        {
            get
            {
                if (_audiofileRepository == null)
                {
                    _audiofileRepository = new AudiofileRepository(_context);
                }
                return _audiofileRepository;
            }
        }

        public RatingRepository RatingRepository
        {
            get
            {
                if (_ratingRepository == null)
                {
                    _ratingRepository = new RatingRepository(_context);
                }
                return _ratingRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
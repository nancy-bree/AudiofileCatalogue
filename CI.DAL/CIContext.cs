using CI.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CI.DAL
{
    public class CIContext : DbContext
    {
        public DbSet<Audiofile> Audiofiles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audiofile>()
                .HasMany(x => x.Votes)
                .WithRequired(x => x.Audiofile);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Votes)
                .WithRequired(x => x.User);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
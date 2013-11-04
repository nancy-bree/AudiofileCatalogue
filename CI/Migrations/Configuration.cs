namespace CI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CI.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<CI.DAL.CIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CI.DAL.CIContext context)
        {
            /*Author author = new Author
            {
                Name = "Bob Dylan"
            };
            context.Authors.AddOrUpdate(author);
            context.SaveChanges();


            Genre genre = new Genre
            {
                Name = "Áëþç"
            };
            context.Genres.AddOrUpdate(genre);
            context.SaveChanges();


            Audiofile audiofile = new Audiofile
            {
                Title = "Ballad of a Thin Man",
                AuthorID = author.ID,
                GenreID = genre.ID,
                Description = "...",
                Year = 1965,
                Filename = "c880546f-82bf-4e6b-9f5b-17a916d5bb51.mp3"
            };
            context.Audiofiles.AddOrUpdate(audiofile);

            User user = new User
            {
                Username = "JohnDoe",
                Password = "123"
            };
            context.Users.AddOrUpdate(user);
            context.SaveChanges();


            Rating rating = new Rating
            {
                AudiofileID = audiofile.ID,
                UserID = user.ID,
                Vote = 1
            };
            context.Ratings.AddOrUpdate(rating);
            context.SaveChanges();*/

        }
    }
}

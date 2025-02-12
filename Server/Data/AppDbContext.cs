using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserComic> UserComics { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comic> Comics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Iron Man", Picture = "https://image.tmdb.org/t/p/original/zDN5cF6nATORm4EMUSuuwJ97DuK.jpg" },
                new Movie { Id = 2, Title = "Iron Man 2", Picture = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p3546118_p_v10_af.jpg" }
            );

            modelBuilder.Entity<Comic>().HasData(
       new Comic { Id = 1, Title = "Marvel Previews (2017)", Picture = "http://i.annihil.us/u/prod/marvel/i/mg/c/80/5e3d7536c8ada", Extension = "jpg", Price = 10.99m },
       new Comic { Id = 2, Title = "Iron Man (2022) #1", Picture = "http://i.annihil.us/u/prod/marvel/i/mg/b/c0/639a7b035cbaa", Extension = "jpg",  Price = 21.99m }
   );

            modelBuilder.Entity<UserProfile>().HasData(
       new UserProfile
       {
           Id = 1,
           Name = "Steve Rodgers",
           Email = "steverodgers@avengers.com",
           Bio = "I can do this all day",
           ProfileImage = "https://ca.slack-edge.com/T6G3NJMK5-U02S94DBXLP-d199360ebd76-512",
           UserWins = 10,
           UserLosses = 2
       },
       new UserProfile
       {
           Id = 2,
           Name = "Tony Stark",
           Email = "tonystark@avengers.com",
           Bio = "Genius, billionaire, playboy, philanthropist",
           ProfileImage = "https://media1.popsugar-assets.com/files/thumbor/ZCWD9YXxqYzk9riO2WR2OrxzWUw/721x0:1801x1080/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2019/07/01/098/n/46207611/5d2cc4f65d1ab1d1992803.52716266_/i/Why-Tony-Stark-Best-Marvel-Character.jpg",
           UserWins = 3000,
           UserLosses = 1
       }
   );

            modelBuilder.Entity<UserComic>().HasData(
     new UserComic { Id = 1, UserId = 1, ComicId = 1 },
     new UserComic { Id = 2, UserId = 1, ComicId = 2 }
 );

            modelBuilder.Entity<UserMovie>().HasData(
                new UserMovie { Id = 1, UserId = 1, MovieId = 1 },
                new UserMovie { Id = 2, UserId = 2, MovieId = 2 }
            );
            modelBuilder.Entity<UserComic>()
         .HasOne(uc => uc.UserProfile)
         .WithMany(up => up.FavoriteComics)
         .HasForeignKey(uc => uc.UserId)
         .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<UserMovie>()
          .HasOne(um => um.UserProfile)
          .WithMany(up => up.FavoriteMovies)
          .HasForeignKey(um => um.UserId)
          .OnDelete(DeleteBehavior.Cascade);


        }

    }
}

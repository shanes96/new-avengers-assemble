namespace Server.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio {  get; set; }
        public string ProfileImage { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserComic> FavoriteComics { get; set; }
        public ICollection<UserMovie> FavoriteMovies { get; set; }
        public int? UserWins { get; set; }
        public int? UserLosses { get; set; }
        public bool? IsLoggedOn { get; set; }
    }
}

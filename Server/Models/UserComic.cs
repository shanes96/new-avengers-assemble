namespace Server.Models
{
    public class UserComic
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ComicId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Comic Comic { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class UserMovie
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public int UserId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}

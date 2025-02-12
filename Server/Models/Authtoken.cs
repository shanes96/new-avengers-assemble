using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class AuthToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Token { get; set; } 

        [Required]
        public int UserId { get; set; } 

        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; } 

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Expires { get; set; }
    }
}


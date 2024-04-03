using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Owner { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(16)")]
        public string Rating { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(256)")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}

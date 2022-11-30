using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatecBackend.Domain
{
    public class BlogPost
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public string? Tittle { get; set; }
        [Required]
        public DateTime? PublishDate { get; set; }
        public ICollection<PostComment>? PostComment { get; set; }
    }
}

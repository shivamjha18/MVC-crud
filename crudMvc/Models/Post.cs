using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crudMvc.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? Title { get; set; }
        [DisplayName("Body of this Blog")]
        public string? Body { get; set; }
        public string? Image { get; set; }
    }
}

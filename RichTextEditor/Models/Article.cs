using System.ComponentModel.DataAnnotations;

namespace RichTextEditor.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<Url>? Urls { get; set; }
    }
}

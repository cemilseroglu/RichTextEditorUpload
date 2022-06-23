namespace RichTextEditor.Models
{
    public class ArticleViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Url> Urls { get; set; }
    }
}

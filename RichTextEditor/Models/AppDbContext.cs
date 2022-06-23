using Microsoft.EntityFrameworkCore;

namespace RichTextEditor.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Url> Urls { get; set; }
    }
}

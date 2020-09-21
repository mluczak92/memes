using Microsoft.EntityFrameworkCore;

namespace memes.Models {
    public class MemesContext : DbContext {
        public MemesContext(DbContextOptions<MemesContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Tag>()
                .HasIndex(u => u.Value)
                .IsUnique();
        }
    }
}

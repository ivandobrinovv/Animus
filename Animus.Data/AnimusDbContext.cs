using Animus.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Animus.Data
{
    public class AnimusDbContext : DbContext
    {
        public AnimusDbContext(DbContextOptions<AnimusDbContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder
                .Entity<Section>()
                .HasMany(s => s.Posts);

            modelBuilder
                .Entity<Post>()
                .HasMany(p => p.Photos);

            modelBuilder
                .Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Parent)
                .HasForeignKey(p => p.ParentId);

            modelBuilder
                .Entity<Like>()
                .HasKey(l => new { l.UserId, l.PostId });

            base.OnModelCreating(modelBuilder);
        }
    }
}

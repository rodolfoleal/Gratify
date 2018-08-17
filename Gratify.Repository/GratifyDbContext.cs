using Gratify.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrossSolar.Repository
{
    public class GratifyDbContext : IdentityDbContext
    {
        public GratifyDbContext()
        {
        }

        public GratifyDbContext(DbContextOptions<GratifyDbContext> options) : base(options)
        {
        }

        public DbSet<WishList> WishLists { get; set; }

        public DbSet<Item> Items { get; set; }

        public new DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserToUser>()
                .HasKey(k => new { k.FollowingId, k.FollowerId });

            modelBuilder.Entity<UserToUser>()
                .HasOne(l => l.Following)
                .WithMany(a => a.Followers)
                .HasForeignKey(l => l.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserToUser>()
                .HasOne(l => l.Follower)
                .WithMany(a => a.Following)
                .HasForeignKey(l => l.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
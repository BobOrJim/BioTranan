using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//add-migration "v01"
//update-database

namespace Infrastructure.EF_experiment
{
    public class GradesDbContext : DbContext
    {
        public GradesDbContext(DbContextOptions<GradesDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PostsDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post { PostId = 1, Title = "Post 1", Content = "Content 1" });
            modelBuilder.Entity<Post>().HasData(new Post { PostId = 2, Title = "Post 2", Content = "Content 2" });

            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 1, Text = "Hej", PostId = 1 });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 2, Text = "Hej igen", PostId = 1 });
        }
    }
}

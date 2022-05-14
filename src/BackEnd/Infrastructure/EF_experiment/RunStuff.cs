using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF_experiment
{
    public class RunStuff
    {
        private readonly GradesDbContext _gradesDbContext;

        public RunStuff(GradesDbContext gradesDbContext)
        {
            _gradesDbContext = gradesDbContext;
        }
        public void Run()
        {
            //Load Post only
            Post? loadPost = _gradesDbContext.Posts.FirstOrDefault();

            //Load Post with related comments
            Post? loadPostWithComments = _gradesDbContext.Posts.Include(p => p.Comments).FirstOrDefault();

            //Save Post only
            _gradesDbContext.Posts.Add(new Post { Title = "Soligt idag", Content = "Åker och badar" });

            //Save Post with related comments
            Post savePostWithComments = new Post { Title = "Regnar idag", Content = "Bakar bullar" };
            Comment comment1 = new Comment { Text = "fina bullar" };
            Comment comment2 = new Comment { Text = "mums mums" };
            savePostWithComments.Comments.Add(comment1);
            savePostWithComments.Comments.Add(comment2);
            _gradesDbContext.Posts.Add(savePostWithComments);
            _gradesDbContext.SaveChanges();
        }
        public void Run2()
        {
            //Add one comment to a post, write back to db
            Post? loadPost = _gradesDbContext.Posts.Where(p => p.PostId == 5).FirstOrDefault();
            Comment comment = new Comment { Text = "Tycker dina bullar var fula" };
            loadPost.Comments.Add(comment);
            _gradesDbContext.Posts.Update(loadPost);
            _gradesDbContext.SaveChanges();
        }

    }
}

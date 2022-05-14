using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF_experiment
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public List<Comment> Comments { get; } = new();  //Convention till EF för att bygga relationen      
    }
}

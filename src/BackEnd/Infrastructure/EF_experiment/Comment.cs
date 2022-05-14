using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF_experiment
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; } = "";
        public int PostId { get; set; } //FK
        public Post Post { get; set; } //Convention till EF för att bygga relationen

    }
}

using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Review : BaseEntity
    {
        //public Guid Id { get; set; }
        public Guid MovieShowId { get; set; } // EF will map this to MovieShow.Id


        [Range(1, 5, ErrorMessage = "Alowed grades are 1->5")]
        public int Rating { get; set; }

        [Range(0, 10000, ErrorMessage = "Comment maximun char count is 10000")]
        public string? Comment { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Salon : BaseEntity
    {
        //public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = "";

        [Range(0, 200, ErrorMessage = "Max size is 1000 seats")]
        public int TotalSeats { get; set; }
        
        
        public ICollection<MovieShow>? MovieShows { get; set; } //EF will map this to the join table
    }
}



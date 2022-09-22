namespace Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Dealer
    {
        public Dealer()
        {
            Cars = new List<Car>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }


        [Required]
        public string UserId { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}

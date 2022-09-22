namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class SearchByBrand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}

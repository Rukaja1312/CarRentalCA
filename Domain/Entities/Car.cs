namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public SearchByBrand Brand { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [Range(1940, 2022)]
        public int Year { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Description { get; set; }

        public byte[]? Image { get; set; }

        [ForeignKey("Dealer")]
        public int DealerId { get; set; }
    }
}

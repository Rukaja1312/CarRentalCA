namespace Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [MinLength(5)]
        [MaxLength(50)]
        public string FullName { get; set; }
    }
}

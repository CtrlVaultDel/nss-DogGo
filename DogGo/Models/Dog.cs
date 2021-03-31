using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Owner")]
        public int OwnerId { get; set; }
        [Required]
        public string Breed { get; set; }
        public string Notes { get; set; }

        [Display(Name="Picture")]
        public string ImageUrl { get; set; }
    }
}

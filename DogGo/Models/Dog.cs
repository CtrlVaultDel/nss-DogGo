using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Owner")]
        public int OwnerId { get; set; }
        public string Breed { get; set; }
        public string Notes { get; set; }

        [Display(Name="Picture")]
        public string ImageUrl { get; set; }
    }
}

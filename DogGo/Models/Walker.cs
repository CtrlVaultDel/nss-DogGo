using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }
        [DisplayName("Profile Picture")]
        public string ImageUrl { get; set; }
        [DisplayName("Total Walk Time")]
        public string TotalWalkTime { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
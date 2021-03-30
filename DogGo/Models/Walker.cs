using System.ComponentModel.DataAnnotations;
using System;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Neighborhood")]
        public int NeighborhoodId { get; set; }
        public string ImageUrl { get; set; }
        public string TotalWalkTime { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
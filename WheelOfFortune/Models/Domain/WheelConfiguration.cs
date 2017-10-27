using System;
using System.ComponentModel.DataAnnotations;

namespace WheelOfFortune.Models.Domain
{
    public class WheelConfiguration
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
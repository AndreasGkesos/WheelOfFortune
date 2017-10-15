using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelOfFortune.Models.Domain
{
    public class WheelConfiguration
    {
        public WheelConfiguration()
        {
            Spins = new List<Spin>();
            Slices = new List<WheelConfigurationSlice>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<Spin> Spins { get; set; }
        public ICollection<WheelConfigurationSlice> Slices { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelOfFortune.Models.Domain
{
    public class WheelConfigurationSlice
    {
        public WheelConfigurationSlice()
        {
            WheelConfigurations = new List<WheelConfiguration>();
        }

        public int Id { get; set; }

        [Required]
        public double Propability { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value{get; set;}
        [Required]
        public bool Win { get; set; }
        [Required]
        public string ResultText { get; set; }
        [Required]
        public double Score { get; set; }

        public ICollection<WheelConfiguration> WheelConfigurations { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
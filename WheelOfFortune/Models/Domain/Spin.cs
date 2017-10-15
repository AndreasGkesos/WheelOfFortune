using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelOfFortune.Models.Domain
{
    public class Spin
    {
        public Spin()
        {
            WheelConfigurations = new List<WheelConfiguration>();
        }

        public int Id { get; set; }

        [Required]
        public double ScoreValue { get; set;}
        [Required]
        public double BetValue { get; set;}
        [Required]
        public double ResultValue { get; set;}
        [Required]
        public DateTime ExecutionDate { get; set; }


        public ICollection<WheelConfiguration> WheelConfigurations { get; set; }

        [Required]
        public ApplicationUser User { get; set; }


    }
}
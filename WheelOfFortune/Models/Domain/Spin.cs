using System;
using System.ComponentModel.DataAnnotations;

namespace WheelOfFortune.Models.Domain
{
    public class Spin
    {
        public int Id { get; set; }

        [Required]
        public decimal ScoreValue { get; set;}
        [Required]
        public decimal BetValue { get; set;}
        [Required]
        public decimal ResultValue { get; set;}
        [Required]
        public DateTime ExecutionDate { get; set; }

        public WheelConfiguration WheelConfiguration { get; set; }

        [Required]
        public ApplicationUser User { get; set; }


    }
}
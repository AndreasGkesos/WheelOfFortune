using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
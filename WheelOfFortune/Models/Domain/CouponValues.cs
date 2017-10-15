using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelOfFortune.Models.Domain
{
    public class CouponValues
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
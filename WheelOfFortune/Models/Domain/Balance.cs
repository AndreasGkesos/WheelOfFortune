using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelOfFortune.Models.Domain
{
    public class Balance
    {

        public int Id { get; set; }

        [Required]
        public long BalanceValue { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public Balance()
        {
            BalanceValue = 100;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WheelOfFortune.Models.Domain
{
    public class Balance
    {
        public int Id { get; set; }

        [Required]
        public decimal BalanceValue { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

       
    }
}

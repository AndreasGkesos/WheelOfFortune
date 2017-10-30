namespace WheelOfFortune.Models.ViewModels
{
    public class BalanceViewModel
    {
        public int Id { get; set; }
        public decimal BalanceValue { get; set; }
        public ApplicationUserViewModel User { get; set; }
    }
}
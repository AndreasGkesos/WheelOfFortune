using System;

namespace WheelOfFortune.Models.ViewModels
{
    public class SpinBindingModel
    {
        public decimal ScoreValue { get; set; }
        public decimal BetValue { get; set; }
        public decimal ResultValue { get; set; }
        public DateTime ExecutionDate { get; set; }

        public int WheelConfigurationId { get; set; }
    }

    public class SpinViewModel
    {
        public int Id { get; set; }
        public decimal ScoreValue { get; set; }
        public decimal BetValue { get; set; }
        public decimal ResultValue { get; set; }
        public DateTime ExecutionDate { get; set; }

        public int WheelConfigurationId { get; set; }

        public ApplicationUserViewModel User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;

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
}
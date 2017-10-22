using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models.ViewModels
{
    public class SpinBindingModel
    {
        public double ScoreValue { get; set; }
        public double BetValue { get; set; }
        public double ResultValue { get; set; }
        public DateTime ExecutionDate { get; set; }

        public int WheelConfigurationId { get; set; }
    }
}
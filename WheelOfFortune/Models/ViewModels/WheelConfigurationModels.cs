using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models.ViewModels
{
    public class WheelDataViewModel
    {
        public int configId { get; set; }
        public IList<string> colorArray { get; set; }
        public IList<WheelConfigurationSliceViewModel> segmentValuesArray { get; set; }
        public int svgWidth { get; set; }
        public int svgHeight { get; set; }
        public string wheelStrokeColor { get; set; }
        public int wheelStrokeWidth { get; set; }
        public int wheelSize { get; set; }
        public int wheelTextOffsetY { get; set; }
        public string wheelTextColor { get; set; }
        public string wheelTextSize { get; set; }
        public int wheelImageOffsetY { get; set; }
        public int wheelImageSize { get; set; }
        public int centerCircleSize { get; set; }
        public string centerCircleStrokeColor { get; set; }
        public int centerCircleStrokeWidth { get; set; }
        public string centerCircleFillColor { get; set; }
        public string segmentStrokeColor { get; set; }
        public int segmentStrokeWidth { get; set; }
        public int centerX { get; set; }
        public int centerY { get; set; }
        public bool hasShadows { get; set; }
        public int numSpins { get; set; }
        public IList<string> spinDestinationArray { get; set; }
        public int minSpinDuration { get; set; }
        public string gameOverText { get; set; }
        public string invalidSpinText { get; set; }
        public string introText { get; set; }
        public bool hasSound { get; set; }
        public string gameId { get; set; }
        public bool clickToSpin { get; set; }
    }

    public class WheelConfigurationBindingModel
    {
        public IList<WheelConfigurationSliceBindingModel> Slices { get; set; }
    }

    public class WheelConfigurationSliceBindingModel
    {
        public double Probability { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Win { get; set; }
        public string ResultText { get; set; }
        public double Score { get; set; }
        public WheelConfiguration WheelConfiguration { get; set; }
    }

    public class WheelConfigurationSliceViewModel
    {
        public double probability { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public bool win { get; set; }
        public string resultText { get; set; }
        public UserDataViewModel userData { get; set; }
    }

    public class UserDataViewModel
    {
        public double score { get; set; }
    }
}
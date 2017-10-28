using System;
using System.Collections.Generic;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{   
    
    public class WheelConfigurationController : ApiController
    {
        private readonly IWheelConfigurationRepo _repo;
        private readonly IWheelConfigurationSliceRepo _slicesRepo;

        public WheelConfigurationController(IWheelConfigurationRepo repo, IWheelConfigurationSliceRepo slicesRepo)
        {
           _repo = repo;
           _slicesRepo = slicesRepo;
        }

        [HttpGet]
        public WheelDataViewModel GetWheelConfiguration()
        {
            var config = _repo.GetWheelConfiguration();
            var slices = _slicesRepo.GetByWheelConfigurationId(config.Id);

            return new WheelDataViewModel
            {
                configId = config.Id,
                colorArray = new List<string> { "#364C62", "#F1C40F", "#E67E22", "#E74C3C", "#ECF0F1", "#95A5A6", "#16A085", "#27AE60", "#2980B9", "#8E44AD", "#2C3E50", "#F39C12", "#D35400", "#C0392B", "#BDC3C7","#1ABC9C", "#2ECC71", "#E87AC2", "#3498DB", "#9B59B6", "#7F8C8D" },
                segmentValuesArray = slices, 
                svgWidth = 1024,
                svgHeight = 768,
                wheelStrokeColor = "#D0BD0C",
                wheelStrokeWidth = 18,
                wheelSize = 700,
                wheelTextOffsetY = 80,
                wheelTextColor = "#000",
                wheelTextSize = "2.3em",
                wheelImageOffsetY = 40,
                wheelImageSize = 50,
                centerCircleSize = 0,
                centerCircleStrokeColor = "#F1DC15",
                centerCircleStrokeWidth = 12,
                centerCircleFillColor = "#EDEDED",
                segmentStrokeColor = "#E2E2E2",
                segmentStrokeWidth = 4,
                centerX = 512,
                centerY = 384,
                hasShadows = false,
                numSpins = 999,
                spinDestinationArray = new List<string>(),
                minSpinDuration = 6,
                gameOverText = "GAME OVER",
                invalidSpinText = "INVALID SPIN. PLEASE SPIN AGAIN.",
                introText = "YOU HAVE TO<br>SPIN IT <span style='color:#F282A9;'>2</span> WIN IT!",
                hasSound = true,
                gameId = "9a0232ec06bc431114e2a7f3aea03bbe2164f1aa",
                clickToSpin = true

            };
        }

        [HttpPost]
        public Tuple<WheelConfiguration, Exception> AddWheelConfiguration(WheelConfigurationBindingModel model)
        {
            var wheel = _repo.CreateWheelConfig();

            if (wheel.Item2 != null) return new Tuple<WheelConfiguration, Exception>(null, wheel.Item2);

            foreach (var s in model.Slices)
            {
                s.WheelConfiguration = wheel.Item1;
                _slicesRepo.CreateSlice(s);
            }
            return new Tuple<WheelConfiguration, Exception>(wheel.Item1, null);
        }
    }
}
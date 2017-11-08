﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Services;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WheelOfFortune.Controllers.API
{   
    public class SpinsController : ApiController
    {
        private readonly IWheelService _wheelService;

        public SpinsController(IWheelService wheelService)
        {
            _wheelService = wheelService;
        }

        [HttpGet]
        public IEnumerable<SpinViewModel> GetAll()
        {
            return _wheelService.GetAllSpins().Select(TransformModels.ToSpinViewModel);
        }

        [HttpGet]
        public IEnumerable<SpinViewModel> GetByUserId(string userId)
        {
            return _wheelService.GetSpinByUserId(userId).Select(TransformModels.ToSpinViewModel);
        }

        [HttpPost]
        public SpinViewModel AddSpin(SpinBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToSpinViewModel(_wheelService.CreateSpin(model, userId));
        }
    }
}
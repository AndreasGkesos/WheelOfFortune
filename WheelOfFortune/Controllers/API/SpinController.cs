using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{
    public class SpinController : ApiController
    {
        private readonly ISpinRepo repo;

        public SpinController(ISpinRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IList<Spin> GetByUserId(string userId)
        {
            return repo.GetByUserId(userId);
        }

        [HttpPost]
        public Spin AddSpin(SpinBindingModel model)
        {
            return repo.CreateSpin(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
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

        [HttpGet]
        public Spin AddSpin(string userId)
        {
            return repo.CreateSpin(userId);
        }
    }
}
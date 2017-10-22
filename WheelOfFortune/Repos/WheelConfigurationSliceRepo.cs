using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class WheelConfigurationSliceRepo : IWheelConfigurationSliceRepo
    {
        private readonly ApplicationDbContext context;

        public WheelConfigurationSliceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<WheelConfigurationSlice> GetByWheelConfigurationId(int configId)
        {
            return context.WheelConfigurationSlices.Where(x => x.WheelConfiguration.Id == configId).ToList();
        }
    }
}
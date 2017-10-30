using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class WheelConfigurationSliceRepo : IWheelConfigurationSliceRepo
    {
        private readonly ApplicationDbContext _context;

        public WheelConfigurationSliceRepo(ApplicationDbContext context)
        {
           _context = context;
        }

        public WheelConfigurationSlice CreateSlice(WheelConfigurationSliceBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new Exception("You are not Logged In");

            var slice = new WheelConfigurationSlice
            {
                Propability = model.Probability,
                Value = model.Value,
                Type = model.Type,
                Win = model.Win,
                ResultText = model.ResultText,
                Score = model.Score,
                User = user,
                WheelConfiguration = model.WheelConfiguration
            };

            _context.WheelConfigurationSlices.Add(slice);
            _context.SaveChanges();

            return slice;
        }

        public IEnumerable<WheelConfigurationSlice> GetByWheelConfigurationId(int configId)
        {
            return _context.WheelConfigurationSlices.Where(x => x.WheelConfiguration.Id == configId).ToList();
        } 
    }
}
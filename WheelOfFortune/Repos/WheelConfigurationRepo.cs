using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class WheelConfigurationRepo : IWheelConfigurationRepo
    {
        private readonly ApplicationDbContext context;

        public WheelConfigurationRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Tuple<WheelConfiguration, Exception> CreateWheelConfig()
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
                var user = context.Users.First(x => x.Id == userId);

                var wheel = new WheelConfiguration();
                if (user != null)
                {
                    wheel = new WheelConfiguration
                    {
                        User = user,
                        DateCreated = DateTime.Now
                    };

                    context.WheelConfigurations.Add(wheel);
                    context.SaveChanges();

                    return new Tuple<WheelConfiguration, Exception>(wheel, null);
                }
                else { return new Tuple<WheelConfiguration, Exception>(null, new Exception("You are not Logged In")); }
            }
            catch (NullReferenceException e)
            {
                return new Tuple<WheelConfiguration, Exception>(null, new Exception("You are not Logged In")); ;
            }
        }

        public IList<WheelConfiguration> GetByUserId(string userId)
        {
            return context.WheelConfigurations.Where(x => x.User.Id == userId).ToList();
        }

        public WheelConfiguration GetWheelConfiguration()
        {
            var currentWheel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentWheelConfiguration"]);

            return context.WheelConfigurations.Where(x => x.Id == currentWheel).First();
        }
    }
}
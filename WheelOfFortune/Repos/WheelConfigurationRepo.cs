using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class WheelConfigurationRepo : IWheelConfigurationRepo
    {
        private readonly ApplicationDbContext _context;

        public WheelConfigurationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tuple<WheelConfiguration, Exception> CreateWheelConfig()
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var user = _context.Users.First(x => x.Id == userId);

                if (user == null)
                    return new Tuple<WheelConfiguration, Exception>(null, new Exception("You are not Logged In"));
                
                   var wheel = new WheelConfiguration
                    {
                        User = user,
                        DateCreated = DateTime.Now
                    };

                    _context.WheelConfigurations.Add(wheel);
                    _context.SaveChanges();

                    return new Tuple<WheelConfiguration, Exception>(wheel, null);
               
            }
            catch (NullReferenceException e)
            {
                return new Tuple<WheelConfiguration, Exception>(null, new Exception($"You are not Logged In {e.Message}"));
            }
        }

        public IEnumerable<WheelConfiguration> GetByUserId(string userId)
        {
            return _context.WheelConfigurations.Where(x => x.User.Id == userId).ToList();
        }

        public WheelConfiguration GetWheelConfiguration()
        {
            var currentWheel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentWheelConfiguration"]);

            return _context.WheelConfigurations.First(x => x.Id == currentWheel);
        }
    }
}
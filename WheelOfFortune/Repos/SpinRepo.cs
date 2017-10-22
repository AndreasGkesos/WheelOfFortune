using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class SpinRepo : ISpinRepo
    {
        private readonly ApplicationDbContext context;

        public SpinRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Spin> GetByUserId(string userId)
        {
            return context.Spins.Where(x => x.User.Id == userId).ToList();
        }

        public Spin CreateSpin(SpinBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
                var user = context.Users.Where(x => x.Id == userId).First();

                var spin = new Spin();
                if (user != null)
                {
                    spin = new Spin
                    {
                        BetValue = model.BetValue,
                        ResultValue = model.ResultValue,
                        ScoreValue = model.ScoreValue,
                        User = user,
                        ExecutionDate = DateTime.Now
                    };

                    context.Spins.Add(spin);
                    context.SaveChanges();
                    return spin;
                }
                else { return null; }
            }
            catch (NullReferenceException e )
            {
                return null;
            }          
        }
    }
}
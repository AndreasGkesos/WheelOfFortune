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

        public IEnumerable<Spin> GetByUserId(string userId)
        {
            return context.Spins.Where(x => x.User.Id == userId).ToList();
        }

        public Tuple<Spin, Exception> CreateSpin(SpinBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
                var user = context.Users.First(x => x.Id == userId);

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
                    return new Tuple<Spin, Exception>(spin, null);
                }
                else { return new Tuple<Spin, Exception>(null, new Exception("You are not Logged In")); }
            }
            catch (NullReferenceException e )
            {
                return new Tuple<Spin, Exception>(null, new Exception("You are not Logged In")); ;
            }          
        }
    }
}
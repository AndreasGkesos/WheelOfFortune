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
    public class SpinRepo : ISpinRepo
    {
        private readonly ApplicationDbContext _context;

        public SpinRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SpinViewModel> GetByUserId(string userId)
        {
            return _context.Spins.Where(x => x.User.Id == userId).Select(x => TransformModels.ToSpinViewModel(x)).ToList();
        }

        public Tuple<SpinViewModel, Exception> CreateSpin(SpinBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var user = _context.Users.First(x => x.Id == userId);

               

                if(user == null)
                    return new Tuple<SpinViewModel, Exception>(null, new Exception("You are not Logged In"));

                var spin = new Spin
                {
                    BetValue = model.BetValue,
                    ResultValue = model.ResultValue,
                    ScoreValue = model.ScoreValue,
                    User = user,
                    ExecutionDate = DateTime.Now,
                    WheelConfiguration = _context.WheelConfigurations.First(x => x.Id == model.WheelConfigurationId)                
                };

                _context.Spins.Add(spin);
                _context.SaveChanges();
                var v = TransformModels.ToSpinViewModel(spin);
                return new Tuple<SpinViewModel, Exception>(v, null);
               
            }
            catch (NullReferenceException e )
            {
                return new Tuple<SpinViewModel, Exception>(null, new Exception($"You are not Logged In {e.Message}"));
            }          
        }
    }
}
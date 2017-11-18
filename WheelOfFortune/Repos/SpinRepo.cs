using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<Spin> GetAll()
        {
            return _context.Spins.Include(x => x.User).Include(w => w.WheelConfiguration).ToList();
        }

        public IEnumerable<Spin> GetByUserId(string userId)
        {
            return _context.Spins.Where(x => x.User.Id == userId).Include(x => x.User).Include(w => w.WheelConfiguration).ToList();
        }

        public Spin CreateSpin(SpinBindingModel model, string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new Exception("User does not exist");

            var spin = new Spin
            {
                BetValue = model.BetValue ?? 0,
                ResultValue = model.ResultValue ?? 0,
                ScoreValue = model.ScoreValue ?? 0,
                User = user,
                ExecutionDate = DateTime.Now,
                WheelConfiguration = _context.WheelConfigurations.FirstOrDefault(x => x.Id == model.WheelConfigurationId)
            };

            _context.Spins.Add(spin);
            _context.SaveChanges();

            return spin;         
        }
    }
}
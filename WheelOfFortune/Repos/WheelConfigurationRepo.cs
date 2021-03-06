﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public WheelConfiguration CreateWheelConfig(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new Exception("User does not exist");

            var wheel = new WheelConfiguration
            {
                User = user,
                DateCreated = DateTime.Now
            };

            _context.WheelConfigurations.Add(wheel);
            _context.SaveChanges();

            return wheel;
        }

        public IEnumerable<WheelConfiguration> GetByUserId(string userId)
        {
            return _context.WheelConfigurations.Where(x => x.User.Id == userId).ToList();
        }

        public WheelConfiguration GetWheelConfiguration()
        {
            return _context.WheelConfigurations.OrderByDescending(x => x.Id).Include(x => x.User).First();
        }
    }
}
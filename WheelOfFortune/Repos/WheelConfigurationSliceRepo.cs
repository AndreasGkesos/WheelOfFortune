﻿using Microsoft.AspNet.Identity;
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

        public Tuple<WheelConfigurationSlice, Exception> CreateSlice(WheelConfigurationSliceBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var user = _context.Users.First(x => x.Id == userId);

                if (user == null)
                    return new Tuple<WheelConfigurationSlice, Exception>(null, new Exception("You are not Logged In"));



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
                return new Tuple<WheelConfigurationSlice, Exception>(slice, null);
            }
            catch (NullReferenceException e)
            {
                return new Tuple<WheelConfigurationSlice, Exception>(null, new Exception($"You are not Logged In {e.Message}"));
            }
        }

        public IEnumerable<WheelConfigurationSliceViewModel> GetByWheelConfigurationId(int configId)
        {
            var slices = _context.WheelConfigurationSlices.Where(x => x.WheelConfiguration.Id == configId);
            var results = new List<WheelConfigurationSliceViewModel>();
            foreach (WheelConfigurationSlice w in slices)
            {
                results.Add(TransformModels.ToWheelConfigurationSliceViewModel(w));
            }
            return results.ToList();
        } 
    }
}
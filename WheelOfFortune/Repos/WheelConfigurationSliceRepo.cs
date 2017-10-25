using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
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

        public Tuple<WheelConfigurationSlice, Exception> CreateSlice(WheelConfigurationSliceBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
                var user = context.Users.First(x => x.Id == userId);

                var slice = new WheelConfigurationSlice();
                if (user != null)
                {
                    slice = new WheelConfigurationSlice
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

                    context.WheelConfigurationSlices.Add(slice);
                    context.SaveChanges();
                    return new Tuple<WheelConfigurationSlice, Exception>(slice, null);
                }
                return new Tuple<WheelConfigurationSlice, Exception>(null, new Exception("You are not Logged In"));
            }
            catch (NullReferenceException e)
            {
                return new Tuple<WheelConfigurationSlice, Exception>(null, new Exception("You are not Logged In")); ;
            }
        }

        public IList<WheelConfigurationSliceViewModel> GetByWheelConfigurationId(int configId)
        {
            var slices = context.WheelConfigurationSlices.Where(x => x.WheelConfiguration.Id == configId);
            var results = new List<WheelConfigurationSliceViewModel>();
            foreach (WheelConfigurationSlice w in slices)
            {
                results.Add(ToWheelConfigurationSliceViewModel(w));
            }
            return results;
        }

        private WheelConfigurationSliceViewModel ToWheelConfigurationSliceViewModel(WheelConfigurationSlice model)
        {
            return new WheelConfigurationSliceViewModel
            {
                probability = model.Propability,
                resultText = model.ResultText,
                type = model.Type,
                value = model.Type,
                win = model.Win,
                userData = new UserDataViewModel { score = model.Score }
            };
        }
    }
}
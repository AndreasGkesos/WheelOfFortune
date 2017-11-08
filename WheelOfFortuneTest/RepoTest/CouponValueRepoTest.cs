using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class CouponValueRepoTest : ICouponValueRepo
    {
        private List<CouponValue> list = new List<CouponValue>();

        public CouponValueRepoTest()
        {

        }

        public CouponValue CreateCouponValue(int value)
        {
            var cv = new CouponValue {
                Value = value
            };

            list.Add(cv);
            return cv;
        }

        public IEnumerable<CouponValue> GetAll()
        {
            return list;
        }

        public CouponValue UpdateCouponValue(int id, int value)
        {
            var cv = list.Where(x => x.Id == id).First();
            cv.Value = value;
            return cv;
        }
    }
}

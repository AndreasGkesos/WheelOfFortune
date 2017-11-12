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
            list.Add(new CouponValue { Id = 1, Value = 5 });
            list.Add(new CouponValue { Id = 2, Value = 10 });
            list.Add(new CouponValue { Id = 3, Value = 20 });
            list.Add(new CouponValue { Id = 4, Value = 50 });
        }

        public CouponValue CreateCouponValue(int value)
        {
            return new CouponValue { Id = 1, Value = 5 };
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

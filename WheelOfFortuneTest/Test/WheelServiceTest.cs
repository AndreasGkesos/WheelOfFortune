
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Controllers.API;
using WheelTestingProject.RepoTest;
using System.Linq;
using WheelOfFortune.Services;
using Xunit;
using WheelOfFortune.Models.Domain;
using System;
using WheelOfFortune.Models;
using WheelOfFortune.Models.ViewModels;

namespace WheelTestingProject.ControllerTest
{
    public class WheelServiceTest
    {
        private IWheelService wheelService = new WheelService(new SpinRepoTest(),
                new TransactionRepoTest(),
                new BalanceRepoTest(),
                new CouponRepoTest(),
                new CouponValueRepoTest(),
                new WheelConfigurationTest(),
                new WheelConfigurationSliceTest(),
                new UserRepoTest());
        private ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas", Active = true };
        private ApplicationUser user1 = new ApplicationUser { Id = "aaaaa", Email = "andreas1@gmail.com", UserName = "andreas1", Active = true };
        private string testUserId = "aaaaa";

        [Fact]
        public void TestGetAllSpins()
        {
            int count = wheelService.GetAllSpins().Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public void TestCreateSpin()
        {
            WheelConfiguration wheel = new WheelConfiguration { Id = 1, DateCreated = new DateTime(2017, 10, 10, 10, 20, 4), User = user };

            Spin spin = wheelService.CreateSpin(new WheelOfFortune.Models.ViewModels.SpinBindingModel { BetValue = 10, ExecutionDate = DateTime.Now, ResultValue = 20, ScoreValue = 2, WheelConfigurationId = 1 }, "aaaaa");
            Spin tmpSpin = new Spin { Id = 6, BetValue = 20, ScoreValue = -1, ResultValue = -20.0m, ExecutionDate = new DateTime(2017, 11, 11, 8, 20, 4), User = user, WheelConfiguration = wheel };
            Assert.True(spin.Id == tmpSpin.Id);
            Assert.True(spin.WheelConfiguration.Id == tmpSpin.WheelConfiguration.Id);
            Assert.True(spin.User.Id == tmpSpin.User.Id);
        }

        [Fact]
        public void TestGetSpinByUserId()
        {
            int count = wheelService.GetSpinByUserId(testUserId).Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public void TestGetBalanceObjectByUserId()
        {
            var balance = wheelService.GetBalanceObjectByUserId(testUserId);
            var blc = new Balance { Id = 1, BalanceValue = 100, User = user1 };

            Assert.True(balance.Id == blc.Id);
            Assert.True(balance.BalanceValue == blc.BalanceValue);
            Assert.True(balance.User.Id == blc.User.Id);
        }

        [Fact]
        public void TestUpdateBalance()
        {
            var balance = wheelService.UpdateBalance(10, testUserId);

            Assert.True(balance.BalanceValue == 110);
        }

        [Fact]
        public void TestCreateBalance()
        {
            var balance = wheelService.CreateBalance(testUserId);
            var blc = new Balance { Id = 1, BalanceValue = 100, User = user1 };

            Assert.True(balance.Id == blc.Id);
            Assert.True(balance.BalanceValue == blc.BalanceValue);
            Assert.True(balance.User.Id == blc.User.Id);
        }

        [Fact]
        public void TestGetBalanceByUserId()
        {
            var balance = wheelService.GetBalanceByUserId(testUserId);

            Assert.True(balance == 100);
        }

        [Fact]
        public void TestGetCouponByUserId()
        {
            int count = wheelService.GetCouponByUserId(testUserId).Count();

            Assert.Equal(5, count);
        }

        [Fact]
        public void TestUpdateCouponExpirationDate()
        {
            var date = new DateTime(2017, 10, 10, 10, 20, 4);
            var coupon = wheelService.UpdateCouponExpirationDate(
                new Coupon { Id = 1, Active = true, Code = "ASDFG12345", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2016, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = new CouponValue { Id = 1, Value = 10 }, User = user },
                date);

            Assert.True(date == coupon.DateExpired);
        }

        [Fact]
        public void TestCreateCoupon()
        {
            var coupon = wheelService.CreateCoupon(
                new CouponBindingModel(),
                testUserId);
            var tmpCoupon = new Coupon { Id = 1, Active = true, Code = "ASDFG12345", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = new CouponValue { Id = 1, Value = 10 }, User = user };

            Assert.True(coupon.Id == tmpCoupon.Id);
            Assert.True(coupon.Value.Id == tmpCoupon.Value.Id);
            Assert.True(coupon.User.Id == tmpCoupon.User.Id);
        }

        [Fact]
        public void TestDeleteCoupon()
        {
            var couponStatus = wheelService.DeleteCoupon(1);

            Assert.True(couponStatus);
        }

        [Fact]
        public void TestGetAllCoupons()
        {
            int count = wheelService.GetAllCoupons().Count();

            Assert.Equal(5, count);
        }

        [Fact]
        public void TestExchangeCoupon()
        {
            var result = wheelService.ExchangeCoupon("ASDFG12345", testUserId);

            Assert.True(result);
        }

        [Fact]
        public void TestCreateCouponValue()
        {
            var cv = wheelService.CreateCouponValue(10, user.Id);
            var tmpcv = new CouponValue { Id = 1, Value = 5 };

            Assert.True(cv.Id == tmpcv.Id);
            Assert.True(cv.Value == tmpcv.Value);
        }

        [Fact]
        public void TestUpdateCouponValue()
        {
            var coupon = wheelService.UpdateCouponValue(1, 20);

            Assert.True(coupon.Value == 20);
        }

        [Fact]
        public void TestGetAllUsers()
        {
            int count = wheelService.GetAllUsers().Count();

            Assert.Equal(5, count);
        }

        [Fact]
        public void TestGetUserById()
        {
            var user = wheelService.GetUserById(testUserId);

            Assert.True(user.Id == user1.Id);
            Assert.True(user.Email == user1.Email);
        }

        [Fact]
        public void TestUpdateUserActiveStatusById()
        {
            var status = wheelService.UpdateUserActiveStatusById(false, testUserId);

            Assert.True(status);
        }

        [Fact]
        public void TestGetAllTransactions()
        {
            int count = wheelService.GetAllTransactions().Count();

            Assert.Equal(5, count);
        }

        [Fact]
        public void TestGetTransactionsByUserId()
        {
            int count = wheelService.GetTransactionsByUserId(testUserId).Count();

            Assert.Equal(5, count);
        }

        [Fact]
        public void TestCreateTransaction()
        {
            Transaction transaction = wheelService.CreateTransaction(new TransactionBindingModel { TransactionDate = new DateTime(2017, 11, 11, 8, 20, 4), Type = TransactionType.FromSpin, Value = 20, User = user }, testUserId);
            Transaction tmpTransaction = new Transaction { Id = 1, TransactionDate = new DateTime(2017, 10, 10, 8, 53, 4), Type = TransactionType.FromSpin, Value = 20, User = user };
            Assert.True(transaction.Id == tmpTransaction.Id);
            Assert.True(transaction.TransactionDate == tmpTransaction.TransactionDate);
            Assert.True(transaction.Type == tmpTransaction.Type);
            Assert.True(transaction.Value == tmpTransaction.Value);
            Assert.True(transaction.User.Id == tmpTransaction.User.Id);
        }

        [Fact]
        public void TestGetWheelConfigurationByUserId()
        {
            int count = wheelService.GetWheelConfigurationByUserId(testUserId).Count();

            Assert.Equal(2, count);
        }
    }
}
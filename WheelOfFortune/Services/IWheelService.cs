﻿using System;
using System.Collections.Generic;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Services
{
    public interface IWheelService
    {
        IEnumerable<Spin> GetAllSpins();
        IEnumerable<Spin> GetSpinByUserId(string userId);
        Spin CreateSpin(SpinBindingModel model, string userId);

        Balance GetBalanceObjectByUserId(string userId);
        Balance UpdateBalance(decimal balance, string userId);
        Balance CreateBalance(string userId);
        decimal GetBalanceByUserId(string userId);

        IEnumerable<Coupon> GetCouponByUserId(string userId);
        Coupon UpdateCouponExpirationDate(Coupon coupon, DateTime date);
        Coupon CreateCoupon(int value, string userId);
        IEnumerable<Coupon> GetAllCoupons();
        bool ExchangeCoupon(string code, string userId);
        bool DeleteCoupon(int id);

        CouponValue CreateCouponValue(int value, string userId);
        CouponValue UpdateCouponValue(int id, int value);

        IEnumerable<Transaction> GetTransactionsByUserId(string userId);
        Transaction CreateTransaction(TransactionBindingModel model, string userId);
        IEnumerable<Transaction> GetAllTransactions();

        IEnumerable<WheelConfiguration> GetWheelConfigurationByUserId(string userId);
        WheelDataViewModel GetWheelConfiguration();
        WheelConfiguration CreateWheelConfig(WheelConfigurationBindingModel model, string userId);

        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(string userId);
        byte[] GetUserImage(string userId);
        bool UpdateUserActiveStatusById(bool status, string userId);

        IEnumerable<CouponValue> GetCouponValues();
    }
}
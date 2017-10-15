using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelOfFortune.Models.ViewModels
{
    public class TransactionViewModel
    {
        public enum TransactionType
        {
            FromCoupon,
            FromSpin
        }
    }
}
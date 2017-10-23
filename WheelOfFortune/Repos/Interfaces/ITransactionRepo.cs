using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ITransactionRepo
    {
        IList<Transaction> GetByUserId(string userId);
        Tuple<Transaction, Exception> CreateTransaction(TransactionBindingModel model);
    }
}
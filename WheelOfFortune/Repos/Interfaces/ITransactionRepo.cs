using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ITransactionRepo
    {
        IEnumerable<Transaction> GetByUserId(string userId);
        Tuple<TransactionViewModel, Exception> CreateTransaction(TransactionBindingModel model);
        IEnumerable<Transaction> GetAll();
    }
}
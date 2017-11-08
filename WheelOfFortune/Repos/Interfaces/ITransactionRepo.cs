using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ITransactionRepo
    {
        IEnumerable<Transaction> GetByUserId(string userId);
        Transaction CreateTransaction(TransactionBindingModel model, string userId);
        IEnumerable<Transaction> GetAll();
    }
}
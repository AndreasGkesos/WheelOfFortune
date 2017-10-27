﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tuple<Transaction, Exception> CreateTransaction(TransactionBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var user = _context.Users.First(x => x.Id == userId);

              if(user==null)
                  return new Tuple<Transaction, Exception>(null, new Exception("You are not Logged In"));

                var transaction = new Transaction
                    {
                        TransactionDate = model.TransactionDate,
                        Value = model.Value,
                        Type = model.Type,
                        User = user
                    };

                    _context.Transactions.Add(transaction);
                    _context.SaveChanges();
                    return new Tuple<Transaction, Exception>(transaction, null);
              
               
            }
            catch (NullReferenceException e)
            {
                return new Tuple<Transaction, Exception>(null, new Exception($"You are not Logged In {e.Message }"));
            }
        }

        public IEnumerable<Transaction> GetByUserId(string userId)
        {
            return _context.Transactions.Where(x => x.User.Id == userId).ToList();
        }
    }
}
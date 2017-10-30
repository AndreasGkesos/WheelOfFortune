using System;
using System.Collections.Generic;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{   
    
    public class TransactionController : ApiController
    {
        private readonly ITransactionRepo _repo;

        public TransactionController(ITransactionRepo repo)
        {
           _repo = repo;
        }

        [HttpGet]
        public IEnumerable<TransactionViewModel> GetAll()
        {
            List<TransactionViewModel> list = new List<TransactionViewModel>();
            foreach (Transaction t in _repo.GetAll())
            {
                list.Add(TransformModels.ToTransactionViewModel(t));
            }
            return list;
        }

        [HttpGet]
        public IEnumerable<TransactionViewModel> GetByUserId(string userId)
        {
            List<TransactionViewModel> list = new List<TransactionViewModel>();
            foreach (Transaction t in _repo.GetByUserId(userId))
            {
                list.Add(TransformModels.ToTransactionViewModel(t));
            }
            return list;
        }
    }
}
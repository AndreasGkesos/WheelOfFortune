using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Security.Cryptography;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Services;

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
            return _repo.GetAll().Select(x => TransformModels.ToTransactionViewModel(x));
        }

        [HttpGet]
        public IEnumerable<TransactionViewModel> GetByUserId(string userId)
        {
                return _repo.GetByUserId(EncryptionService.DecryptString(userId)).Select(x => TransformModels.ToTransactionViewModel(x));

        }
    }
}
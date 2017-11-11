using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers.API
{   
    public class TransactionController : ApiController
    {
        private readonly IWheelService _wheelService;

        public TransactionController(IWheelService wheelService)
        {
           _wheelService = wheelService;
        }

        [HttpGet]
        public IEnumerable<TransactionViewModel> GetAll()
        {
            return _wheelService.GetAllTransactions().Select(x => TransformModels.ToTransactionViewModel(x));
        }

        [HttpGet]
        public IEnumerable<TransactionViewModel> GetByUserId(string userId)
        {
            return _wheelService.GetTransactionsByUserId(EncryptionService.DecryptString(userId)).Select(x => TransformModels.ToTransactionViewModel(x));
        }
    }
}
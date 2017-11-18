using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers.API
{
    [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
  
    public class TransactionController : ApiController
    {
        private readonly IWheelService _wheelService;

        public TransactionController(IWheelService wheelService)
        {
           _wheelService = wheelService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<TransactionViewModel> GetAll()
        {
            return _wheelService.GetAllTransactions().Select(x => TransformModels.ToTransactionViewModel(x));
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]

        public IEnumerable<TransactionViewModel> GetByUserId(string userId)
        {
            return _wheelService.GetTransactionsByUserId(userId).Select(x => TransformModels.ToTransactionViewModel(x));
        }
    }
}
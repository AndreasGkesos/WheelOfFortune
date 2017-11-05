using System.Web.Http;
using System.Web.Http.Description;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{
    public class BalanceController : ApiController
    {
        private readonly IBalanceRepo _balanceRepo;

        public BalanceController(IBalanceRepo balanceRepo)
        {
            _balanceRepo = balanceRepo;
        }

        [ResponseType(typeof(decimal))]
        [HttpGet]
        public IHttpActionResult GetBalance(string userId)
        {
           var balance= _balanceRepo.GetBalanceByUserId(userId);

            return Ok(balance);
        }


      
    }
}

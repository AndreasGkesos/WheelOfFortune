using System.Web.Http;
using System.Web.Http.Description;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Services;

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
                var balance = _balanceRepo.GetBalanceByUserId(EncryptionService.DecryptString(userId));

                return Ok(balance);
            
        }


      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;

namespace AdminMonitorApp.Repos.interfaces
{
     public  interface IAdminRepository
     {
         IEnumerable<ApplicationUser> GetRegiteredUsers();
         IEnumerable<Spin> GetAllSpins();
         IEnumerable<Transaction> GetAllTransactions();

         IEnumerable<Balance> GetUserBalance();
         void DeleteUser(string userId);




     }
}

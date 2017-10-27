using System;
using System.Collections.Generic;
using AdminMonitorApp.Repos.interfaces;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;


namespace AdminMonitorApp.Repos
{
    public class AdminRepository:IAdminRepository
    {
        private ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Balance> GetUserBalance()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetRegiteredUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Spin> GetAllSpins()
        {
            throw new NotImplementedException();
        }
    }
}
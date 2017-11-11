using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetAllById(string userId)
        {
            return _context.Users.Where(x => x.Id == userId).First();
        }

        IEnumerable<ApplicationUser> IUserRepo.GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
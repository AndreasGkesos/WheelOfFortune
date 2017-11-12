using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public byte[] GetUserPicture(string userId)
        {
            return _context.Users.Where(x => x.Id == userId).Select(x => x.UserPhoto).FirstOrDefault();
        }

        public bool UpdateUserActiveStatusById(bool status, string userId)
        {
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (user == null) { return false; }

            user.Active = status;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
    }
}
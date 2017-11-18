using System;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UName { get; set; }
        public string Email { get; set; }
        public byte[] UserPhoto { get; set; }
        public bool   Active { get; set; }
    }
}
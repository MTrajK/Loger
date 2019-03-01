using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.ViewModels
{
    public class Settings
    {
        public ActiveUser User { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string AccountPhotoURL { get; set; }
        public string AccountPhotoData { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.ViewModels
{
    public class Comment
    {
        public int LogoId { get; set; }
        public string Username { get; set; }
        public string AccountPhotoURL { get; set; }
        public string AccountURL { get; set; }
        public string Content { get; set; }
    }
}

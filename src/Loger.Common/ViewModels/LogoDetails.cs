using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.ViewModels
{
    public class LogoDetails
    {
        public List<Comment> Comments { get; set; }
        public int LogoId { get; set; }
        public string LogoURL { get; set; }
        public string Username { get; set; }
        public string AccountPhotoURL { get; set; }
        public string AccountURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UploadDate { get; set; }
        public int LikesNum { get; set; }
        public int CommentsNum { get; set; }
        public bool Liked { get; set; }
    }
}

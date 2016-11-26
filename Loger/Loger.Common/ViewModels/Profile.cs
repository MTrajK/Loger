using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Common.ViewModels
{
    public enum FollowingState
    {
        ActiveProfile = 0,      // Logged user profile
        Following = 1,          // Following that user
        NotFollowing = 2        // Not following that user
    }

    public class Profile
    {
        public ActiveUser User { get; set; }
        public List<Card> Cards { get; set; }
        public int UserProfileId { get; set; }
        public string AccountPhotoURL { get; set; }
        public string Username { get; set; }
        public FollowingState Follow { get; set; }
        public int LogosNum { get; set; }
        public int FollowersNum { get; set; }
        public int FollowingNum { get; set; }
    }
}

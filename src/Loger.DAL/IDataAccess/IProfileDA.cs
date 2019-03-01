using Loger.Common.Data;
using Loger.Common.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.IDataAccess
{
    public interface IProfileDA
    {
        User GetUserByID(int id);
        void ChangePasswordByID(int userId, string newPassword);
        void ChangePhotoByID(int userId, string photoURL);
        Follow FollowState(int firstId, int secondId);
        void Follow(Follow user);
        void Unfollow(Follow user);
        Follow CheckFollow(FollowingUser user);
    }
}

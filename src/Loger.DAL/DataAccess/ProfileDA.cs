using Loger.Common.Data;
using Loger.Common.Other;
using Loger.DAL.IDataAccess;
using Loger.DAL.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.DataAccess
{
    public class ProfileDA : IProfileDA
    {

        private ILogerContext _dbContext;

        public ProfileDA(ILogerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByID(int id)
        {
            User user = _dbContext.GetUsers().Where(u => u.ID == id).First();
            return user;
        }

        public void ChangePasswordByID(int userId, string newPassword)
        {
            _dbContext.GetUsers().Where(u => u.ID == userId).First().Password = newPassword;
            _dbContext.Save();
        }

        public void ChangePhotoByID(int userId, string photoURL)
        {
            _dbContext.GetUsers().Where(u => u.ID == userId).First().AccountPhotoURL = photoURL;
            _dbContext.Save();
        }

        public Follow FollowState(int firstId, int secondId)
        {
            try
            {
                Follow follow = _dbContext.GetFollows().Where(f => f.UserFollowingID == firstId && f.UserFollowedID == secondId).First();
                return follow;
            }
            catch
            {
                return null;
            }
        }

        public void Follow(Follow user)
        {
            _dbContext.GetFollows().Add(user);
            _dbContext.Save();
        }

        public void Unfollow(Follow user)
        {
            _dbContext.GetFollows().Remove(user);
            _dbContext.Save();
        }

        public Follow CheckFollow(FollowingUser user)
        {
            try
            {
                Follow follow = _dbContext.GetFollows().Where(f => f.UserFollowingID == user.FromUserId && f.UserFollowedID == user.ToUserId).First();
                return follow;
            }
            catch
            {
                return null;
            }
        }

    }
}

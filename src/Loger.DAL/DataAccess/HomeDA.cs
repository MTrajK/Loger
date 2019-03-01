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
    public class HomeDA : IHomeDA
    {

        private ILogerContext _dbContext;

        public HomeDA(ILogerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByID(int id)
        {
            User user = _dbContext.GetUsers().Where(u => u.ID == id).First();
            return user;
        }

        public List<Photo> getAllLogos()
        {
            List<Photo> photos = _dbContext.GetPhotos().OrderByDescending(d => d.CreatedDate).ToList();
            return photos;
        }

        public List<Photo> getAllFollowingLogosByID(int id)
        {
            List<Photo> photos = _dbContext.GetPhotos().Where(p => p.User.Followeds.Where(u => u.UserFollowingID == id).ToList().Count > 0).OrderByDescending(d => d.CreatedDate).ToList();
            return photos;
        }

        public List<Photo> getAllFavoriteLogosByID(int id)
        {
            List<Photo> photos = _dbContext.GetPhotos().Where(p => p.Likes.Where(l => l.UserID == id).ToList().Count() > 0).OrderByDescending(d => d.CreatedDate).ToList();
            return photos;
        }

        public void UploadLogo(Photo photo)
        {
            _dbContext.GetUsers().Where(u => u.ID == photo.UserID).First().Photos.Add(photo);
            _dbContext.Save();
        }

        public Photo GetLastestUploadById(int id)
        {
            Photo last = _dbContext.GetPhotos().Where(p => p.UserID == id).ToList().Last();
            return last;
        }

        public Like CheckLike(LikedLogo logo)
        {
            try
            {
                Like like = _dbContext.GetLikes().Where(l => l.UserID == logo.FromUserId && l.PhotoID == logo.ToLogoId).First();
                return like;
            }
            catch
            {
                return null;
            }
        }

        public void AddLike(Like like)
        {
            _dbContext.GetLikes().Add(like);
            _dbContext.Save();
        }

        public void DeleteLike(Like like)
        {
            _dbContext.GetLikes().Remove(like);
            _dbContext.Save();
        }

        public Photo GetLogoDetails(int logoId)
        {
            Photo details = _dbContext.GetPhotos().Where(p => p.ID == logoId).First();
            return details;
        }

        public void AddComment(Comment comment)
        {
            _dbContext.GetComments().Add(comment);
            _dbContext.Save();
        }

    }
}

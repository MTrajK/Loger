using Loger.Common.Data;
using Loger.Common.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.IDataAccess
{
    public interface IHomeDA
    {
        User GetUserByID(int id);
        List<Photo> getAllLogos();
        List<Photo> getAllFollowingLogosByID(int id);
        List<Photo> getAllFavoriteLogosByID(int id);
        void UploadLogo(Photo photo);
        Photo GetLastestUploadById(int id);
        Like CheckLike(LikedLogo logo);
        void AddLike(Like like);
        void DeleteLike(Like like);
        Photo GetLogoDetails(int logoId);
        void AddComment(Comment comment);
    }
}

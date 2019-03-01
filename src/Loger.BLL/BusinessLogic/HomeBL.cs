using Loger.BLL.IBusinessLogic;
using Loger.Common.Data;
using Loger.Common.Other;
using Loger.Common.ViewModels;
using Loger.DAL.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.BLL.BusinessLogic
{
    public class HomeBL : IHomeBL
    {

        private IHomeDA _homeDA;

        public HomeBL(IHomeDA homeDA)
        {
            _homeDA = homeDA;
        }

        public Main getAllLogos(int id)
        {
            User activeUser = _homeDA.GetUserByID(id);
            Main main = new Main
            {
                User = new ActiveUser
                {
                    Id = activeUser.ID,
                    Username = activeUser.Username,
                    AccountPhotoURL = activeUser.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + activeUser.ID
                },
                Cards = _homeDA.getAllLogos().Select(p => new Card {
                    LogoId = p.ID,
                    LogoUrl = p.URL,
                    Username = p.User.Username,
                    AccountPhotoURL = p.User.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + p.User.ID,
                    LikesNum = p.Likes.Count,
                    CommentsNum = p.Comments.Count,
                    Title = p.Title,
                    Description = p.Description,
                    UploadDate = p.CreatedDate.ToShortDateString(),
                    Liked = p.Likes.Where(l => l.UserID == activeUser.ID).Count() > 0,
                }).ToList()
            };

            return main;
        }

        public Main getAllFollowingLogos(int id)
        {
            User activeUser = _homeDA.GetUserByID(id);
            Main main = new Main
            {
                User = new ActiveUser
                {
                    Id = activeUser.ID,
                    Username = activeUser.Username,
                    AccountPhotoURL = activeUser.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + activeUser.ID
                },
                Cards = _homeDA.getAllFollowingLogosByID(id).Select(p => new Card
                {
                    LogoId = p.ID,
                    LogoUrl = p.URL,
                    Username = p.User.Username,
                    AccountPhotoURL = p.User.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + p.User.ID,
                    LikesNum = p.Likes.Count,
                    CommentsNum = p.Comments.Count,
                    Title = p.Title,
                    Description = p.Description,
                    UploadDate = p.CreatedDate.ToShortDateString(),
                    Liked = p.Likes.Where(l => l.UserID == activeUser.ID).Count() > 0,
                }).ToList()
            };

            return main;
        }

        public Main getAllFavoriteLogos(int id)
        {
            User activeUser = _homeDA.GetUserByID(id);
            Main main = new Main
            {
                User = new ActiveUser
                {
                    Id = activeUser.ID,
                    Username = activeUser.Username,
                    AccountPhotoURL = activeUser.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + activeUser.ID
                },
                Cards = _homeDA.getAllFavoriteLogosByID(id).Select(p => new Card
                {
                    LogoId = p.ID,
                    LogoUrl = p.URL,
                    Username = p.User.Username,
                    AccountPhotoURL = p.User.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + p.User.ID,
                    LikesNum = p.Likes.Count,
                    CommentsNum = p.Comments.Count,
                    Title = p.Title,
                    Description = p.Description,
                    UploadDate = p.CreatedDate.ToShortDateString(),
                    Liked = p.Likes.Where(l => l.UserID == activeUser.ID).Count() > 0,
                }).ToList()
            };

            return main;
        }

        public string UploadLogo(UploadedLogo logo)
        {
            Photo photo = new Photo
            {
                UserID = logo.UserId,
                Title = logo.Title,
                Description = logo.Description,
                CreatedDate = DateTime.Now,
                URL = logo.LogoData
            };

            _homeDA.UploadLogo(photo);
            return "success";
        }

        public Card GetLastestUploadById(int id)
        {
            Photo last = _homeDA.GetLastestUploadById(id);
            Card newCard = new Card
            {
                LogoId = last.ID,
                LogoUrl = last.URL,
                Username = last.User.Username,
                AccountPhotoURL = last.User.AccountPhotoURL,
                AccountURL = @"/Profile/Index/" + last.User.ID,
                LikesNum = last.Likes.Count,
                CommentsNum = last.Comments.Count,
                Title = last.Title,
                Description = last.Description,
                UploadDate = last.CreatedDate.ToShortDateString(),
                Liked = last.Likes.Where(l => l.UserID == id).Count() > 0
            };

            return newCard;
        }

        public string LikeLogo(LikedLogo logo)
        {
            string response = "fail";
            Like check = _homeDA.CheckLike(logo);

            if (!logo.Liked && check != null)
            {
                _homeDA.DeleteLike(check);
                response = "success";
            } else if (logo.Liked && check == null)
            {
                Like like = new Like
                {
                    UserID = logo.FromUserId,
                    PhotoID = logo.ToLogoId,
                    CreatedDate = DateTime.Now
                };
                _homeDA.AddLike(like);

                response = "success";
            }

            return response;
        }

        public LogoDetails GetLogoDetails(int logoId, int activeUser)
        {
            Photo details = _homeDA.GetLogoDetails(logoId);

            LogoDetails data = new LogoDetails
            {
                LogoId = details.ID,
                LogoURL = details.URL,
                Username = details.User.Username,
                AccountPhotoURL = details.User.AccountPhotoURL,
                AccountURL = @"/Profile/Index/"+details.User.ID,
                Title = details.Title,
                Description = details.Description,
                UploadDate = details.CreatedDate.ToShortDateString(),
                LikesNum = details.Likes.Count,
                CommentsNum = details.Comments.Count,
                Liked = details.Likes.Where(l => l.UserID == activeUser).Count() > 0,
                Comments = details.Comments.Select(c => new Common.ViewModels.Comment
                   {
                       LogoId = c.PhotoID,
                       Username = c.User.Username,
                       AccountPhotoURL = c.User.AccountPhotoURL,
                       AccountURL = @"/Profile/Index/"+c.User.ID,
                       Content = c.Content
                   }).ToList()
            };

            return data;
        }

        public string CommentLogo(CommentedLogo comment)
        {
            Common.Data.Comment newComent = new Common.Data.Comment {
                UserID = comment.FromUserId,
                PhotoID = comment.ToLogoId,
                Content = comment.Content,
                CreatedDate = DateTime.Now
            };

            _homeDA.AddComment(newComent);
            return "success";
        }

    }
}

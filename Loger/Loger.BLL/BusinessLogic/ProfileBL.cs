using Loger.BLL.IBusinessLogic;
using Loger.Common.Data;
using Loger.Common.Other;
using Loger.Common.ViewModels;
using Loger.DAL.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Loger.BLL.BusinessLogic
{
    public class ProfileBL : IProfileBL
    {
        private IProfileDA _profileDA;

        public ProfileBL(IProfileDA profileDA)
        {
            _profileDA = profileDA;
        }

        public Settings GetSettingsView(int id)
        {
            User activeUser = _profileDA.GetUserByID(id);
            Settings settings = new Settings
            {
                User = new ActiveUser
                {
                    Id = activeUser.ID,
                    Username = activeUser.Username,
                    AccountPhotoURL = activeUser.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + activeUser.ID
                },
                Username = activeUser.Username,
                Email = activeUser.Email,
                CurrentPassword = "",
                NewPassword = "",
                ConfirmPassword = "",
                AccountPhotoURL = activeUser.AccountPhotoURL,
                AccountPhotoData = ""
            };

            return settings;
        }

        public string UpdateUserProfile(Settings user)
        {
            string response = "fail";

            if (user.CurrentPassword != null)
            {
                // Converting (encrypt) user plain text password into hashed
                byte[] data = Encoding.ASCII.GetBytes(user.CurrentPassword);
                data = new SHA256Managed().ComputeHash(data);
                string convertedPassword = Encoding.ASCII.GetString(data);

                if (convertedPassword == _profileDA.GetUserByID(user.User.Id).Password)
                {
                    // Convert and change password
                    byte[] newData = Encoding.ASCII.GetBytes(user.NewPassword);
                    newData = new SHA256Managed().ComputeHash(newData);
                    string newPassword = Encoding.ASCII.GetString(newData);

                    _profileDA.ChangePasswordByID(user.User.Id, newPassword);

                    if (user.AccountPhotoData != null)
                    {
                        _profileDA.ChangePhotoByID(user.User.Id, user.AccountPhotoData);
                        response = "photo and password changed";
                    }
                    else
                    {
                        response = "password changed";
                    }
                }
            }
            else if (user.AccountPhotoData != null)
            {
                _profileDA.ChangePhotoByID(user.User.Id, user.AccountPhotoData);
                response = "photo changed";
            }

            return response;
        }

        public Profile GetProfile(int userId, int activeId)
        {
            FollowingState followingState = new FollowingState();
            if (userId == activeId)
            {
                followingState = FollowingState.ActiveProfile;
            } else if (_profileDA.FollowState(activeId, userId) != null)
            {
                followingState = FollowingState.Following;
            } else
            {
                followingState = FollowingState.NotFollowing;
            }

            User activeUser = _profileDA.GetUserByID(activeId);
            User profileUser = _profileDA.GetUserByID(userId);

            Profile data = new Profile
            {
                User = new ActiveUser
                {
                    Id = activeUser.ID,
                    Username = activeUser.Username,
                    AccountPhotoURL = activeUser.AccountPhotoURL,
                    AccountURL = @"/Profile/Index/" + activeUser.ID
                },
                Cards = profileUser.Photos.OrderByDescending(d => d.CreatedDate).Select(p => new Card
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
                }).ToList(),
                UserProfileId = profileUser.ID,
                AccountPhotoURL = profileUser.AccountPhotoURL,
                Username = profileUser.Username,
                Follow = followingState,
                LogosNum = profileUser.Photos.Count,
                FollowersNum = profileUser.Followeds.Count,
                FollowingNum = profileUser.Followings.Count,
            };

            return data;
        }

        public string Follow(FollowingUser user)
        {
            Follow newFollow = new Follow
            {
                UserFollowingID = user.FromUserId,
                UserFollowedID = user.ToUserId,
                CreatedDate = DateTime.Now
            };
            _profileDA.Follow(newFollow);

            return "success";
        }

        public string Unfollow(FollowingUser user)
        {
            string response = "success";
            Follow check = _profileDA.CheckFollow(user);

            if (check != null)
            {
                _profileDA.Unfollow(check);
            }
            else
            {
                response = "fail";
            }
            

            return response;
        }

    }
}

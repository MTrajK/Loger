using Loger.Common.Other;
using Loger.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.BLL.IBusinessLogic
{
    public interface IProfileBL
    {
        Settings GetSettingsView(int id);
        string UpdateUserProfile(Settings user);
        Profile GetProfile(int userId, int activeId);
        string Follow(FollowingUser user);
        string Unfollow(FollowingUser user);
    }
}

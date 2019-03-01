using Loger.Common.Data;
using Loger.Common.Other;
using Loger.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.BLL.IBusinessLogic
{
    public interface IHomeBL
    {
        Main getAllLogos(int id);
        Main getAllFollowingLogos(int id);
        Main getAllFavoriteLogos(int id);
        string UploadLogo(UploadedLogo logo);
        Card GetLastestUploadById(int id);
        string LikeLogo(LikedLogo logo);
        LogoDetails GetLogoDetails(int logoId, int activeUser);
        string CommentLogo(CommentedLogo comment);
    }
}
